using System;
using FinancialPortfolio.DDD;
using FinancialPortfolio.Services.Orders.Domain.Enums;

namespace FinancialPortfolio.Services.Orders.Domain.Events
{
    public record OrderCreatedDomainEvent : IDomainEvent
    {
        public Guid Id { get; }

        public int Version { get; }
        
        public OrderType Type { get; }
        
        public double Amount { get; }
        
        public decimal Price { get; }
        
        public DateTime DateTime { get; }
        
        public decimal Commission { get; }
        
        public Guid AssetId { get; }
        
        public Guid AccountId { get; }

        public OrderCreatedDomainEvent(Guid id, int version, OrderType type, double amount, 
            decimal price, DateTime dateTime, decimal commission, Guid assetId, Guid accountId)
        {
            Id = id;
            Version = version;
            Type = type;
            Amount = amount;
            Price = price;
            DateTime = dateTime;
            Commission = commission;
            AssetId = assetId;
            AccountId = accountId;
        }
    }
}