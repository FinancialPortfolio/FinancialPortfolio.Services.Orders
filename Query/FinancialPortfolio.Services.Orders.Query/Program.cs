using System.Threading.Tasks;

namespace FinancialPortfolio.Services.Orders.Query
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await WebHosting.Application.RunAsync(args, typeof(Startup));
        }
    }
}