using FinancialPortfolio.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents
{
    public class AssetDocument : BaseDocument
    {
        public string Symbol { get; set; }
        
        public string Name { get; set; }
    }
}