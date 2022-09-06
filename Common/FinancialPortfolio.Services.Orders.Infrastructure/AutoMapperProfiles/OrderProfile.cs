using AutoMapper;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events;
using FinancialPortfolio.Services.Orders.Domain.Events;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;
using OrderApi;
using Order = FinancialPortfolio.Services.Orders.Domain.Entities.Order;

namespace FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDocument>().ReverseMap();
            
            CreateMap<Order, OrderResponse>().ReverseMap();
            
            CreateMap<OrderCreatedDomainEvent, OrderCreatedEvent>();
            
            CreateMap<OrderUpdatedDomainEvent, OrderUpdatedEvent>();
            
            CreateMap<OrderDeletedDomainEvent, OrderDeletedEvent>();
        }
    }
}