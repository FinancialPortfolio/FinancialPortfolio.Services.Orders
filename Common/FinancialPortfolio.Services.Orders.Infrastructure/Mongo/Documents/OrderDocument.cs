using System;
using FinancialPortfolio.Mongo.Documents;
using FinancialPortfolio.Services.Orders.Domain.Enums;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents
{
    public class OrderDocument : BaseDocument
    {
        public OrderType Type { get; set; }
        
        public double Amount { get; set; }
        
        public decimal Price { get; set; }
        
        public DateTime DateTime { get; set; }
        
        public decimal Commission { get; set; }
        
        public Guid AssetId { get; set; }
        
        public Guid AccountId { get; set; }
    }
}