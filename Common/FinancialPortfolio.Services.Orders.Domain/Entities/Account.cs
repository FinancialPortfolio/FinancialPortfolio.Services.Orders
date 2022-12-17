using System;
using FinancialPortfolio.DDD;

namespace FinancialPortfolio.Services.Orders.Domain.Entities
{
    public class Account : Entity
    {
        public string Name { get; private set; }
        
        public Guid UserId { get; private set; }

        public Account(Guid id, string name, Guid userId) : base(id)
        {
            Name = name;
            UserId = userId;
        }
        
        public void Update(string name, int version)
        {
            Name = name;
            Version = version;
        }
    }
}