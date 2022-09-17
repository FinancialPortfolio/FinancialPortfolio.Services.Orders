using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Commands;
using FinancialPortfolio.DDD;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Commands;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Events;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.CommandHandlers
{
    public class IntegrateOrdersCommandHandler : ICommandHandler<IntegrateOrdersCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public IntegrateOrdersCommandHandler(
            IOrderRepository orderRepository, IDomainEventPublisher domainEventPublisher, 
            IAccountRepository accountRepository, IStockRepository stockRepository)
        {
            _orderRepository = orderRepository;
            _domainEventPublisher = domainEventPublisher;
            _accountRepository = accountRepository;
            _stockRepository = stockRepository;
        }
        
        public async Task HandleAsync(IntegrateOrdersCommand message, MessagePayload payload)
        {
            var existingAccount = await _accountRepository.GetAsync(message.AccountId);
            if (existingAccount is null)
                throw new DomainModelNotExistsException($"Account with id: {message.AccountId} doesn't exist");

            var assets = await GetAssetsAsync(message);

            var orders = new List<Order>();
            foreach (var command in message.Orders)
            {
                var asset = assets.First(a => a.Symbol == command.Symbol);
                var order = Order.Create(command.Type, command.Amount, command.Price, command.DateTime, command.Commission, asset.Id, message.AccountId);
                orders.Add(order);
            }
            await _orderRepository.CreateManyAsync(orders);

            var events = orders.SelectMany(o => o.Events) as IEnumerable<OrderCreatedDomainEvent>;
            await _domainEventPublisher.PublishAsync(new OrdersIntegratedDomainEvent(events));
        }

        private async Task<IEnumerable<Stock>> GetAssetsAsync(IntegrateOrdersCommand message)
        {
            var symbols = message.Orders.Select(o => o.Symbol);
            var existingAssets = await _stockRepository.GetAllAsync(symbols);
            
            var missingAssets = symbols.Except(existingAssets.Select(a => a.Symbol));
            if (missingAssets.Any())
            {
                var missingSymbols = string.Join(", ", missingAssets);
                throw new DomainModelNotExistsException($"Assets with symbols: {missingSymbols} don't exist");
            }

            return existingAssets;
        }
    }
}