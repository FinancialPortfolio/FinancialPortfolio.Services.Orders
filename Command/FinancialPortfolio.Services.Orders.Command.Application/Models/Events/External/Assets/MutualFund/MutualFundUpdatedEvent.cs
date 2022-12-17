using System;
using FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Asset;

namespace FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.MutualFund
{
    public record MutualFundUpdatedEvent : AssetUpdatedEvent
    {
        public string Exchange { get; }

        public MutualFundUpdatedEvent(Guid id, int version, string symbol, string name, string currency, string exchange)
            : base(id, version, symbol, name, currency)
        {
            Exchange = exchange;
        }
    }
}