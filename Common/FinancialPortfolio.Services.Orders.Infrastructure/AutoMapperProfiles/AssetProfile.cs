using AutoMapper;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Asset;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Bond;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Cryptocurrency;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.IndexFund;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.MutualFund;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Stock;
using FinancialPortfolio.Services.Orders.Domain.Entities.Assets;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents.Assets;

namespace FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDocument>()
                .Include<Bond, BondDocument>()
                .Include<Cryptocurrency, CryptocurrencyDocument>()
                .Include<IndexFund, IndexFundDocument>()
                .Include<MutualFund, MutualFundDocument>()
                .Include<Stock, StockDocument>();
            
            CreateMap<AssetDocument, Asset>()
                .Include<BondDocument, Bond>()
                .Include<CryptocurrencyDocument, Cryptocurrency>()
                .Include<IndexFundDocument, IndexFund>()
                .Include<MutualFundDocument, MutualFund>()
                .Include<StockDocument, Stock>();
            
            CreateMap<Bond, BondDocument>().ReverseMap();
            CreateMap<Cryptocurrency, CryptocurrencyDocument>().ReverseMap();
            CreateMap<IndexFund, IndexFundDocument>().ReverseMap();
            CreateMap<MutualFund, MutualFundDocument>().ReverseMap();
            CreateMap<Stock, StockDocument>().ReverseMap();
                        
            CreateMap<AssetCreatedEvent, Asset>()
                .Include<BondCreatedEvent, Bond>()
                .Include<CryptocurrencyCreatedEvent, Cryptocurrency>()
                .Include<IndexFundCreatedEvent, IndexFund>()
                .Include<MutualFundCreatedEvent, MutualFund>()
                .Include<StockCreatedEvent, Stock>();
            
            CreateMap<BondCreatedEvent, Bond>();
            CreateMap<CryptocurrencyCreatedEvent, Cryptocurrency>();
            CreateMap<IndexFundCreatedEvent, IndexFund>();
            CreateMap<MutualFundCreatedEvent, MutualFund>();
            CreateMap<StockCreatedEvent, Stock>();
            
            CreateMap<BondUpdatedEvent, Bond>();
            CreateMap<CryptocurrencyUpdatedEvent, Cryptocurrency>();
            CreateMap<IndexFundUpdatedEvent, IndexFund>();
            CreateMap<MutualFundUpdatedEvent, MutualFund>();
            CreateMap<StockUpdatedEvent, Stock>();
        }
    }
}