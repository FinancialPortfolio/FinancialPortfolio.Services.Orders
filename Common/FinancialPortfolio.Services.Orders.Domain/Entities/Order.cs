using System;
using FinancialPortfolio.DDD;
using FinancialPortfolio.Services.Orders.Domain.Enums;
using FinancialPortfolio.Services.Orders.Domain.Events;

namespace FinancialPortfolio.Services.Orders.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public OrderType Type { get; private set; }
        
        public double Amount { get; private set; }
        
        public decimal Price { get; private set; }
        
        public DateTime DateTime { get; private set; }
        
        public decimal Commission { get; private set; }
        
        public Guid AssetId { get; private set; }
        
        public Guid AccountId { get; private set; }

        private Order(OrderType type, double amount, decimal price, DateTime dateTime, decimal commission, Guid assetId, Guid accountId)
        {
            Type = type;
            Amount = amount;
            Price = price;
            DateTime = dateTime;
            Commission = commission;
            AssetId = assetId;
            AccountId = accountId;
        }

        public static Order Create(OrderType type, double amount, decimal price, DateTime dateTime, decimal commission, Guid assetId, Guid accountId)
        {
            var order = new Order(type, amount, price, dateTime, commission, assetId, accountId);
            order.AddEvent(new OrderCreatedDomainEvent(order.Id, order.Version, order.Type, 
                order.Amount, order.Price, order.DateTime, order.Commission, order.AssetId, order.AccountId));

            return order;
        }
        
        public void Update(OrderType type, double amount, decimal price, DateTime dateTime, decimal commission, Guid assetId)
        {
            Type = type;
            Amount = amount;
            Price = price;
            DateTime = dateTime;
            Commission = commission;
            AssetId = assetId;
            
            AddEvent(new OrderUpdatedDomainEvent(Id, Version, Type, Amount, Price, DateTime, Commission, AssetId,  AccountId));
        }
    }
}