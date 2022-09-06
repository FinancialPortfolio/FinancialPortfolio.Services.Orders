using AutoMapper;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Stock, StockDocument>().ReverseMap();
            
            CreateMap<StockCreatedEvent, Stock>();
        }
    }
}