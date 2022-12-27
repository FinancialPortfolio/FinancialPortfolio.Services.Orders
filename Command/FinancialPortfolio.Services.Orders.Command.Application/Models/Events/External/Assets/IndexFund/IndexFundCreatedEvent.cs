using System;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Asset;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.IndexFund
{
    public record IndexFundCreatedEvent : AssetCreatedEvent
    {
        public string Exchange { get; }

        public IndexFundCreatedEvent(Guid id, int version, string symbol, string name, string currency, string exchange)
            : base(id, version, symbol, name, currency)
        {
            Exchange = exchange;
        }
    }
}