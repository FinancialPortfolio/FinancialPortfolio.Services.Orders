namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents
{
    public class StockDocument : AssetDocument
    {
        public string Exchange { get; set; }
        
        public string Currency { get; set; }
    }
}