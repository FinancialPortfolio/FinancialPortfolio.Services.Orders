using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Commands;
using FinancialPortfolio.DDD;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Commands;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Entities.Assets;
using FinancialPortfolio.Services.Orders.Domain.Events;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.CommandHandlers
{
    public class IntegrateOrdersCommandHandler : ICommandHandler<IntegrateOrdersCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public IntegrateOrdersCommandHandler(
            IOrderRepository orderRepository, IDomainEventPublisher domainEventPublisher, 
            IAccountRepository accountRepository, IAssetRepository assetRepository)
        {
            _orderRepository = orderRepository;
            _domainEventPublisher = domainEventPublisher;
            _accountRepository = accountRepository;
            _assetRepository = assetRepository;
        }
        
        public async Task HandleAsync(IntegrateOrdersCommand message, MessagePayload payload)
        {
            var existingAccount = await _accountRepository.GetAsync(message.AccountId);
            if (existingAccount is null)
                throw new DomainModelNotExistsException($"Account with id: {message.AccountId} doesn't exist");

            var orders = await GetOrdersAsync(message, existingAccount.UserId);
            
            await _orderRepository.CreateManyAsync(orders);

            var events = orders.SelectMany(o => o.Events).Select(e => e as OrderCreatedDomainEvent).ToList();
            await _domainEventPublisher.PublishAsync(new OrdersIntegratedDomainEvent(events));
        }

        private async Task<IEnumerable<Order>> GetOrdersAsync(IntegrateOrdersCommand message, Guid userId)
        {
            var symbols = message.Orders.Select(o => o.Symbol);
            var assets = await _assetRepository.GetAllAsync(symbols);
            
            var orders = new List<Order>();
            foreach (var command in message.Orders)
            {
                var asset = assets.FirstOrDefault(asset => Compare(command, asset));
                if (asset is null)
                    continue;
                
                var order = Order.Create(command.Type, command.Amount, command.Price, command.DateTime, command.Commission, asset.Id, message.AccountId, userId);
                orders.Add(order);
            }

            return orders;
        }
        
        private static bool Compare(IntegrateOrderCommand order, Asset asset)
        {
            if (order.Symbol != asset.Symbol)
                return false;
            
            if (order.Currency is not null && order.Currency != asset.Currency)
                return false;

            if (order.Exchange is not null)
            {
                return asset switch
                {
                    Stock stock => stock.Exchange == order.Exchange,
                    IndexFund indexFund => indexFund.Exchange == order.Exchange,
                    MutualFund mutualFund => mutualFund.Exchange == order.Exchange,
                    _ => false
                };
            }
            return true;
        }
    }
}