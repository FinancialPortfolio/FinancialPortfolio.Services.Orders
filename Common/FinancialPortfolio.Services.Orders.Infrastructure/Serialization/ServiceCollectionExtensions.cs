using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Serialization
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSerializationSettings(this IServiceCollection services)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                SerializationBinder = new AssetTypeSerializationBinder()
            };
            
            return services;
        }
    }
}