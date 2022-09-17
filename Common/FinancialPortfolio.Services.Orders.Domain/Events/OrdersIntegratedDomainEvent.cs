using System.Collections.Generic;
using FinancialPortfolio.DDD;

namespace FinancialPortfolio.Services.Orders.Domain.Events
{
    public record OrdersIntegratedDomainEvent : IDomainEvent
    {
        public IEnumerable<OrderCreatedDomainEvent> Orders { get; }

        public OrdersIntegratedDomainEvent(IEnumerable<OrderCreatedDomainEvent> orders)
        {
            Orders = orders;
        }
    }
}