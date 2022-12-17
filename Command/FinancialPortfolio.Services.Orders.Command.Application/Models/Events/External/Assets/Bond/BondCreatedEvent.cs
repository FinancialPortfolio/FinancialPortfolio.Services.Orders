using System;
using FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Asset;

namespace FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Bond
{
    public record BondCreatedEvent : AssetCreatedEvent
    {
        public BondCreatedEvent(Guid id, int version, string symbol, string name, string currency) 
            : base(id, version, symbol, name, currency)
        {
        }
    }
}