using System;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Asset
{
    [Message("Assets", "Asset")]
    public record AssetCreatedEvent : IEvent
    {
        public Guid Id { get; }
        
        public int Version { get; }
        
        public string Symbol { get; }
        
        public string Name { get; }
        
        public string Currency { get; }

        public AssetCreatedEvent(Guid id, int version, string symbol, string name, string currency)
        {
            Id = id;
            Version = version;
            Symbol = symbol;
            Name = name;
            Currency = currency;
        }
    }
}