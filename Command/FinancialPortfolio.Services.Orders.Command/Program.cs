using System.Threading.Tasks;
using FinancialPortfolio.Infrastructure;

namespace FinancialPortfolio.Services.Orders.Command
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            await HostApplication.RunAsync(args, Startup.ConfigureServices);
        }
    }
}