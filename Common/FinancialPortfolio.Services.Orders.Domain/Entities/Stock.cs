namespace FinancialPortfolio.Services.Orders.Domain.Entities
{
    public class Stock : Asset
    {
        public string Exchange { get; private set; }
        
        public string Currency { get; private set; }

        public Stock(string symbol, string name, string exchange, string currency) : base(symbol, name)
        {
            Exchange = exchange;
            Currency = currency;
        }
    }
}