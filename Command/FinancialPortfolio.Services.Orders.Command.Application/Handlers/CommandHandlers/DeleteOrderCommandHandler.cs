using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Commands;
using FinancialPortfolio.DDD;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Commands;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions;
using FinancialPortfolio.Services.Orders.Domain.Events;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.CommandHandlers
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IDomainEventPublisher domainEventPublisher)
        {
            _orderRepository = orderRepository;
            _domainEventPublisher = domainEventPublisher;
        }
        
        public async Task HandleAsync(DeleteOrderCommand message, MessagePayload payload)
        {
            var order = await _orderRepository.GetAsync(message.Id);
            if (order is null)
                return;

            if (order.AccountId != message.AccountId)
                throw new InvalidAccountIdException($"Order with id: {message.Id} doesn't belong to account {message.AccountId}.");
            
            await _orderRepository.DeleteAsync(order.Id);

            await _domainEventPublisher.PublishAsync(new OrderDeletedDomainEvent(order.Id));
        }
    }
}