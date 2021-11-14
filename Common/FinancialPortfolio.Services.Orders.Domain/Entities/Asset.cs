using System;
using FinancialPortfolio.DDD;

namespace FinancialPortfolio.Services.Orders.Domain.Entities
{
    public class Asset : Entity
    {
        public string Symbol { get; }
        
        public string Name { get; }

        public Asset(Guid id, string symbol, string name) : base(id)
        {
            Symbol = symbol;
            Name = name;
        }
    }
}