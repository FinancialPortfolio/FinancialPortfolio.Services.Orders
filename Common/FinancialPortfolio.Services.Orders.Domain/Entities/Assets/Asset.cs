using FinancialPortfolio.DDD;

namespace FinancialPortfolio.Services.Orders.Domain.Entities.Assets
{
    public abstract class Asset : Entity, IAggregateRoot
    {
        public string Symbol { get; private set; }
        
        public string Name { get; private set; }
        
        public string Currency { get; private set; }
        
        protected Asset(string symbol, string name, string currency)
        {
            Symbol = symbol;
            Name = name;
            Currency = currency;
        }
    }
}