using System;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Accounts
{
    [Message("Accounts", "Account")]
    public record AccountDeletedEvent : IEvent
    {
        public Guid Id { get; }

        public AccountDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}