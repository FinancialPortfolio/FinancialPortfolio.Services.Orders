using System;
using FinancialPortfolio.CQRS.Commands;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Commands
{
    [Message("Orders", "Order")]
    public record DeleteOrderCommand : ICommand
    {
        public Guid Id { get; }
        
        public Guid AccountId { get; }

        public DeleteOrderCommand(Guid id, Guid accountId)
        {
            Id = id;
            AccountId = accountId;
        }
    }
}