namespace FinancialPortfolio.Services.Orders.Domain.Entities.Assets
{
    public class Bond : Asset
    {
        public Bond(string symbol, string name, string currency) : base(symbol, name, currency)
        {
        }
    }
}