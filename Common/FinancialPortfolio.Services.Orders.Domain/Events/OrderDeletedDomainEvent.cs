using System;
using FinancialPortfolio.DDD;

namespace FinancialPortfolio.Services.Orders.Domain.Events
{
    public record OrderDeletedDomainEvent : IDomainEvent
    {
        public Guid Id { get; }

        public OrderDeletedDomainEvent(Guid id)
        {
            Id = id;
        }
    }
}