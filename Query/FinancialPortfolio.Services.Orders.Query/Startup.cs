using FinancialPortfolio.Infrastructure.Shared.Extensions;
using FinancialPortfolio.Infrastructure.WebApi.Extensions;
using FinancialPortfolio.Operations.Grpc.Extensions;
using FinancialPortfolio.Operations.WebApi.Extensions;
using FinancialPortfolio.Services.Orders.Infrastructure.AutoMapperProfiles;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.EntityConfigurations;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Repositories;
using FinancialPortfolio.Services.Orders.Query.Application.Services;
using FinancialPortfolio.Services.Orders.Query.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinancialPortfolio.Services.Orders.Query
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        private IConfiguration Configuration { get; }
        
        private IWebHostEnvironment WebHostEnvironment { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomProblemDetails(WebHostEnvironment)
                .AddLogging(Configuration)
                .AddGrpcOperationContext()
                .AddDefaultRepositoryImplementations(typeof(OrderRepository).Assembly)
                .AddMongo(Configuration, typeof(MongoModelConfiguration).Assembly)
                .AddCustomAutoMapper(typeof(AssetProfile).Assembly)
                .AddCustomGrpc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseOperationContextMiddleware();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<OrderService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}