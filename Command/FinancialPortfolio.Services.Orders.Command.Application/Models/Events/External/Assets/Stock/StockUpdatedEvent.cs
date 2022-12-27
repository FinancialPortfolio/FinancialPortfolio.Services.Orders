using System;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Asset;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Stock
{
    public record StockUpdatedEvent : AssetUpdatedEvent
    {
        public string Exchange { get; }

        public StockUpdatedEvent(Guid id, int version, string symbol, string name, string currency, string exchange)
            : base(id, version, symbol, name, currency)
        {
            Exchange = exchange;
        }
    }
}