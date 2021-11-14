using System;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External
{
    [Message("Accounts", "Account")]
    public record AccountCreatedEvent : IEvent
    {
        public Guid Id { get; }
        
        public string Name { get; }

        public AccountCreatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}