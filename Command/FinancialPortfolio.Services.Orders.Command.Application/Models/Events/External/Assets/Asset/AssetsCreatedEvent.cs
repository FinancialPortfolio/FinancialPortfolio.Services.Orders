using System.Collections.Generic;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;

namespace FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Asset
{
    [Message("Assets", "Asset")]
    public record AssetsCreatedEvent : IEvent
    {
        public IEnumerable<AssetCreatedEvent> Assets { get; }

        public AssetsCreatedEvent(IEnumerable<AssetCreatedEvent> assets)
        {
            Assets = assets;
        }
    }
}