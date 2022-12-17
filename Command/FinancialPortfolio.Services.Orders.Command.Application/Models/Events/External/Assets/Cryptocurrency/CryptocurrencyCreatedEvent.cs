using System;
using FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Asset;

namespace FinancialPortfolio.Services.Categories.Command.Application.Models.Events.External.Assets.Cryptocurrency
{
    public record CryptocurrencyCreatedEvent : AssetCreatedEvent
    {
        public CryptocurrencyCreatedEvent(Guid id, int version, string symbol, string name, string currency)
            : base(id, version, symbol, name, currency)
        {
        }
    }
}