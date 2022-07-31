using System.Threading.Tasks;
using FinancialPortfolio.Infrastructure.WebApi;

namespace FinancialPortfolio.Services.Orders.Query
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await WebApplication.RunAsync(args, typeof(Startup));
        }
    }
}