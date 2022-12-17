using System;
using FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Asset;

namespace FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Stock
{
    public record StockCreatedEvent : AssetCreatedEvent
    {
        public string Exchange { get; }

        public StockCreatedEvent(Guid id, int version, string symbol, string name, string currency, string exchange)
            : base(id, version, symbol, name, currency)
        {
            Exchange = exchange;
        }
    }
}