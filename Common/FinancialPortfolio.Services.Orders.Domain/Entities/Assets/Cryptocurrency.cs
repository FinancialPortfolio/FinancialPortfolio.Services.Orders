namespace FinancialPortfolio.Services.Orders.Domain.Entities.Assets
{
    public class Cryptocurrency : Asset
    {
        public Cryptocurrency(string symbol, string name, string currency) : base(symbol, name, currency)
        {
        }
    }
}