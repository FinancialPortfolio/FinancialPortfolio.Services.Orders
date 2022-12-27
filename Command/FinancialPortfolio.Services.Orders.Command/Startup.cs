using FinancialPortfolio.Infrastructure.Extensions;
using FinancialPortfolio.Infrastructure.Shared.Extensions;
using FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.EntityConfigurations;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Repositories;
using FinancialPortfolio.Services.Orders.Infrastructure.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinancialPortfolio.Services.Orders.Command
{
    public static class Startup
    {
        public static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services
                .AddSerializationSettings()
                .AddDefaultRepositoryImplementations(typeof(OrderRepository).Assembly)
                .AddMongo(hostContext.Configuration, typeof(MongoModelConfiguration).Assembly)
                .AddInMemoryDomainEventPublisher()
                .AddDefaultDomainEventHandlers()
                .AddKafkaCQRSMessaging(hostContext.Configuration, hostContext.HostingEnvironment.EnvironmentName)
                .AddCustomAutoMapper(typeof(OrderProfile).Assembly); 
        }
    }
}