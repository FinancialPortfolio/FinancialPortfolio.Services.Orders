using FinancialPortfolio.Infrastructure.Extensions;
using FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.EntityConfigurations;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinancialPortfolio.Services.Orders.Command
{
    public static class Startup
    {
        public static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services
                .AddDefaultRepositoryImplementations(typeof(OrderRepository).Assembly)
                .AddInMemoryDomainEventPublisher()
                .AddMongo(hostContext.Configuration, typeof(MongoModelConfiguration).Assembly)
                .AddKafkaCQRSMessaging(hostContext.Configuration, hostContext.HostingEnvironment.EnvironmentName)
                .AddCustomAutoMapper(typeof(AssetProfile).Assembly); 
        }
    }
}