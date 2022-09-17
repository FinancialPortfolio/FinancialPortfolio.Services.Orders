using System.Collections.Generic;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events
{
    [Message("Orders", "Order")]
    public record OrdersIntegratedEvent : IEvent
    {
        public IEnumerable<OrderCreatedEvent> Orders { get; }

        public OrdersIntegratedEvent(IEnumerable<OrderCreatedEvent> orders)
        {
            Orders = orders;
        }
    }
}