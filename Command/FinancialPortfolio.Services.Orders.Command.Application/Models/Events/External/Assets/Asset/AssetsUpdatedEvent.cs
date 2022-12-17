using System.Collections.Generic;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Asset
{
    [Message("Assets", "Asset")]
    public record AssetsUpdatedEvent : IEvent
    {
        public IEnumerable<AssetUpdatedEvent> Assets { get; }

        public AssetsUpdatedEvent(IEnumerable<AssetUpdatedEvent> assets)
        {
            Assets = assets;
        }
    }
}