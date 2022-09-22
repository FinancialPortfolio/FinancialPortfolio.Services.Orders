using System;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets
{
    [Message("Assets", "Stock")]
    public record StockCreatedEvent : IEvent
    {
        public Guid Id { get; }
        
        public string Symbol { get; }
        
        public string Name { get; }
        
        public string Exchange { get; }
        
        public string Currency { get; }

        public StockCreatedEvent(Guid id, string symbol, string name, string exchange, string currency)
        {
            Id = id;
            Symbol = symbol;
            Name = name;
            Exchange = exchange;
            Currency = currency;
        }
    }
}