using System;
using FinancialPortfolio.Mongo.ModelConfigurations;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.EntityConfigurations
{
    public class MongoModelConfiguration : IModelConfiguration
    {
        public void Configure()
        {
            BsonClassMap.RegisterClassMap<OrderDocument>(cm =>
            {
                cm.MapProperty(u => u.Type);
                cm.MapProperty(u => u.Amount);
                cm.MapProperty(u => u.Price);
                cm.MapProperty(u => u.Commission);
                cm.MapProperty(u => u.DateTime).SetIsRequired(true);
                cm.MapProperty(u => u.DateTime).SetSerializer(new DateTimeSerializer(DateTimeKind.Utc, BsonType.String));
                cm.MapProperty(u => u.AssetId);
                cm.MapProperty(u => u.AccountId);
            });
            
            BsonClassMap.RegisterClassMap<AccountDocument>(cm =>
            {
                cm.MapProperty(u => u.Name).SetIsRequired(true);
            });
            
            BsonClassMap.RegisterClassMap<AssetDocument>(cm =>
            {
                cm.MapProperty(u => u.Symbol).SetIsRequired(true);
                cm.MapProperty(u => u.Name).SetIsRequired(true);
            });
            
            BsonClassMap.RegisterClassMap<StockDocument>(cm =>
            {
                cm.MapProperty(u => u.Exchange).SetIsRequired(true);
            });
        }
    }
}