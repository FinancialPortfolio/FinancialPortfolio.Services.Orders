using System.Linq;
using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Commands;
using FinancialPortfolio.DDD;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Commands;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository, IDomainEventPublisher domainEventPublisher, 
            IAccountRepository accountRepository, IStockRepository stockRepository)
        {
            _orderRepository = orderRepository;
            _domainEventPublisher = domainEventPublisher;
            _accountRepository = accountRepository;
            _stockRepository = stockRepository;
        }
        
        public async Task HandleAsync(CreateOrderCommand message, MessagePayload payload)
        {
            var existingAccount = await _accountRepository.GetAsync(message.AccountId);
            if (existingAccount is null)
                throw new DomainModelNotExistsException($"Account with id: {message.AccountId} doesn't exist");
            
            var existingAsset = await _stockRepository.GetAsync(message.AssetId);
            if (existingAsset is null)
                throw new DomainModelNotExistsException($"Asset with id: {message.AssetId} doesn't exist");
            
            var order = Order.Create(message.Type, message.Amount, message.Price, 
                message.DateTime, message.Commission, message.AssetId, message.AccountId);
            await _orderRepository.CreateAsync(order);

            await _domainEventPublisher.PublishAsync(order.Events.ToList());
        }
    }
}