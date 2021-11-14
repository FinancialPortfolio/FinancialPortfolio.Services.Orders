using System;
using FinancialPortfolio.DDD;

namespace FinancialPortfolio.Services.Orders.Domain.Entities
{
    public class Account : Entity
    {
        public string Name { get; }

        public Account(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}