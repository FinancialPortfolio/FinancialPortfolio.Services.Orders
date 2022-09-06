using System.Collections.Generic;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets
{
    [Message("Assets", "Stock")]
    public record StocksCreatedEvent : IEvent
    {
        public List<StockCreatedEvent> Stocks { get; }

        public StocksCreatedEvent(List<StockCreatedEvent> stocks)
        {
            Stocks = stocks;
        }
    }
}