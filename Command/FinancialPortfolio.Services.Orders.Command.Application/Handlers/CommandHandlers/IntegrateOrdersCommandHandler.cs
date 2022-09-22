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

            var orders = await GetOrdersAsync(message);
            
            await _orderRepository.CreateManyAsync(orders);

            var events = orders.SelectMany(o => o.Events) as IEnumerable<OrderCreatedDomainEvent>;
            await _domainEventPublisher.PublishAsync(new OrdersIntegratedDomainEvent(events));
        }

        private async Task<IEnumerable<Order>> GetOrdersAsync(IntegrateOrdersCommand message)
        {
            var symbols = message.Orders.Select(o => o.Symbol);
            var stocks = await _stockRepository.GetAllAsync(symbols);
            
            var orders = new List<Order>();
            foreach (var command in message.Orders)
            {
                var stock = stocks.FirstOrDefault(stock => Compare(command, stock));
                if (stock is null)
                    continue;
                
                var order = Order.Create(command.Type, command.Amount, command.Price, command.DateTime, command.Commission, stock.Id, message.AccountId);
                orders.Add(order);
            }

            return orders;
        }
        
        private static bool Compare(IntegrateOrderCommand order, Stock stock)
        {
            if (order.Symbol != stock.Symbol)
                return false;
            
            if (order.Currency is not null && order.Currency != stock.Currency)
                return false;
            
            if (order.Exchange is not null && order.Exchange != stock.Exchange)
                return false;

            return true;
        }
    }
}