using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPortfolio.Services.Orders.Domain.Entities;

namespace FinancialPortfolio.Services.Orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        
        Task<IEnumerable<Order>> GetAllAsync();
    }
}