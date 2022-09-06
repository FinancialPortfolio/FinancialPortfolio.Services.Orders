using FinancialPortfolio.DDD;

namespace FinancialPortfolio.Services.Orders.Domain.Entities
{
    public abstract class Asset : Entity
    {
        public string Symbol { get; private set; }
        
        public string Name { get; private set; }
        
        protected Asset(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }
    }
}