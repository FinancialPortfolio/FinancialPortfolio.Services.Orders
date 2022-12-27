using System;
using System.Linq;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Asset;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Bond;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Cryptocurrency;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.IndexFund;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.MutualFund;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Stock;
using Newtonsoft.Json.Serialization;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Serialization
{
    public class AssetTypeSerializationBinder : ISerializationBinder
    {
        public Type BindToType(string assemblyName, string assemblyTypeName)
        {
            var typeName = assemblyTypeName.Split(".").LastOrDefault();
            
            return typeName switch
            {
                nameof(AssetCreatedEvent) => typeof(AssetCreatedEvent),
                nameof(BondCreatedEvent) => typeof(BondCreatedEvent),
                nameof(CryptocurrencyCreatedEvent) => typeof(CryptocurrencyCreatedEvent),
                nameof(IndexFundCreatedEvent) => typeof(IndexFundCreatedEvent),
                nameof(MutualFundCreatedEvent) => typeof(MutualFundCreatedEvent),
                nameof(StockCreatedEvent) => typeof(StockCreatedEvent),
                
                nameof(AssetUpdatedEvent) => typeof(AssetUpdatedEvent),
                nameof(BondUpdatedEvent) => typeof(BondUpdatedEvent),
                nameof(CryptocurrencyUpdatedEvent) => typeof(CryptocurrencyUpdatedEvent),
                nameof(IndexFundUpdatedEvent) => typeof(IndexFundUpdatedEvent),
                nameof(MutualFundUpdatedEvent) => typeof(MutualFundUpdatedEvent),
                nameof(StockUpdatedEvent) => typeof(StockUpdatedEvent),
                
                _ => null
            };
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
}