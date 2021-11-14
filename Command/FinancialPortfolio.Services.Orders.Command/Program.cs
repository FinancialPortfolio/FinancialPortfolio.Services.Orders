using System.Threading.Tasks;

namespace FinancialPortfolio.Services.Orders.Command
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            await Hosting.Application.RunAsync(args, Startup.ConfigureServices);
        }
    }
}