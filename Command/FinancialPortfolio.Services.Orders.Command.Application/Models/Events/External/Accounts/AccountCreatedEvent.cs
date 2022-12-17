using System;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Accounts
{
    [Message("Accounts", "Account")]
    public record AccountCreatedEvent : IEvent
    {
        public Guid Id { get; }
        
        public string Name { get; }
        
        public Guid UserId { get; }

        public AccountCreatedEvent(Guid id, string name, Guid userId)
        {
            Id = id;
            Name = name;
            UserId = userId;
        }
    }
}