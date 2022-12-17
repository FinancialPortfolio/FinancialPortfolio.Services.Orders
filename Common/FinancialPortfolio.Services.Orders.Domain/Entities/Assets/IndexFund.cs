namespace FinancialPortfolio.Services.Orders.Domain.Entities.Assets
{
    public class IndexFund : Asset
    {
        public string Exchange { get; private set; }
        
        private IndexFund(string symbol, string name, string currency, string exchange) : base(symbol, name, currency)
        {
            Exchange = exchange;
        }
    }
}