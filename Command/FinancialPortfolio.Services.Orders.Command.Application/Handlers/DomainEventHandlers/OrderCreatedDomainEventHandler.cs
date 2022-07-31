using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events;
using FinancialPortfolio.Services.Orders.Domain.Events;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.DomainEventHandlers
{
    public class OrderCreatedDomainEventHandler : IMessageHandler<OrderCreatedDomainEvent>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        
        public OrderCreatedDomainEventHandler(IEventPublisher eventPublisher, IMapper mapper)
        {
            _eventPublisher = eventPublisher;
            _mapper = mapper;
        }

        public async Task HandleAsync(OrderCreatedDomainEvent @event, MessagePayload payload)
        {
            var integrationEvent = _mapper.Map<OrderCreatedEvent>(@event);
            await _eventPublisher.PublishAsync(integrationEvent);

        }
    }
}