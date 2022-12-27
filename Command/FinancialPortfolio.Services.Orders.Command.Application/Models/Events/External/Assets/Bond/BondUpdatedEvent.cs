using System;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Asset;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Bond
{
    public record BondUpdatedEvent : AssetUpdatedEvent
    {
        public BondUpdatedEvent(Guid id, int version, string symbol, string name, string currency)
            : base(id, version, symbol, name, currency)
        {
        }
    }
}