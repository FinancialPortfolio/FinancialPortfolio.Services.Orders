using FinancialPortfolio.Infrastructure.WebApi.Extensions;
using FinancialPortfolio.Services.Orders.Query.Application.Models.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NotFoundProblemDetails = FinancialPortfolio.ProblemDetails.Grpc.ProblemDetails.NotFoundProblemDetails;

namespace FinancialPortfolio.Services.Orders.Query.Extensions
{
    public static class ProblemDetailsServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddGrpcProblemDetails(env, settings =>
            {
                settings.Map<DomainModelNotExistsException>(exception => new NotFoundProblemDetails(exception));
            });
            
            return services;
        }
    }
}