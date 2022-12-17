using System;
using FinancialPortfolio.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents
{
    public class AccountDocument : BaseDocument
    {
        public string Name { get; set; }
        
        public Guid UserId { get; set; }
    }
}