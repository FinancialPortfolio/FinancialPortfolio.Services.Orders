using AutoMapper;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDocument>().ReverseMap();
        }
    }
}