namespace FinancialPortfolio.Services.Orders.Domain.Entities.Assets
{
    public class Stock : Asset
    {
        public string Exchange { get; private set; }

        public Stock(string symbol, string name, string currency, string exchange) : base(symbol, name, currency)
        {
            Exchange = exchange;
        }
    }
}