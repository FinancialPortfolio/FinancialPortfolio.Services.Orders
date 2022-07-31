using System;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External
{
    [Message("Assets", "Asset")]
    public record AssetCreatedEvent : IEvent
    {
        public Guid Id { get; }
        
        public string Symbol { get; }
        
        public string Name { get; }

        public AssetCreatedEvent(Guid id, string symbol, string name)
        {
            Id = id;
            Symbol = symbol;
            Name = name;
        }
    }
}