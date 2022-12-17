namespace FinancialPortfolio.Services.Orders.Domain.Entities.Assets
{
    public class MutualFund: Asset
    {
        public string Exchange { get; private set; }
        
        public MutualFund(string symbol, string name, string currency, string exchange) : base(symbol, name, currency)
        {
            Exchange = exchange;
        }
    }
}