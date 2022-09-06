using System;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events
{
    [Message("Orders", "Order")]
    public record OrderDeletedEvent : IEvent
    {
        public Guid Id { get; }

        public OrderDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}