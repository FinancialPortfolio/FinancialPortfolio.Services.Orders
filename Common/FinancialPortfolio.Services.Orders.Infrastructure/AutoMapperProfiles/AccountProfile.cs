using AutoMapper;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDocument>().ReverseMap();
        }
    }
}