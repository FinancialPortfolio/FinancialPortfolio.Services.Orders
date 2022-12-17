using FinancialPortfolio.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents.Assets
{
    public class AssetDocument : BaseDocument
    {
        public string Symbol { get; set; }
        
        public string Name { get; set; }
        
        public string Currency { get; set; }
    }
}