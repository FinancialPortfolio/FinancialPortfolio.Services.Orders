using System.Collections.Generic;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;
using Newtonsoft.Json;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Asset
{
    [Message("Assets", "Asset")]
    public record AssetsUpdatedEvent : IEvent
    {
        public List<AssetUpdatedEvent> Assets { get; }

        public AssetsUpdatedEvent([JsonProperty(ItemTypeNameHandling = TypeNameHandling.All)] List<AssetUpdatedEvent> assets)
        {
            Assets = assets;
        }
    }
}