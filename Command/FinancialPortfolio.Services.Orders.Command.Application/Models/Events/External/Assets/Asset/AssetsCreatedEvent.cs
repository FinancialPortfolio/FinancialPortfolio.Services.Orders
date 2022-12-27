using System.Collections.Generic;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Attributes;
using Newtonsoft.Json;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Asset
{
    [Message("Assets", "Asset")]
    public record AssetsCreatedEvent : IEvent
    {
        public List<AssetCreatedEvent> Assets { get; }

        public AssetsCreatedEvent([JsonProperty(ItemTypeNameHandling = TypeNameHandling.All)] List<AssetCreatedEvent> assets)
        {
            Assets = assets;
        }
    }
}