using System;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Accounts
{
    [Message("Accounts", "Account")]
    public record AccountUpdatedEvent : IEvent
    {
        public Guid Id { get; }

        public int Version { get; }

        public string Name { get; }

        public AccountUpdatedEvent(Guid id, int version, string name)
        {
            Id = id;
            Version = version;
            Name = name;
        }
    }
}