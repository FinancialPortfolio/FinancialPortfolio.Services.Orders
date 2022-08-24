using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPortfolio.Search;
using FinancialPortfolio.Services.Orders.Domain.Entities;

namespace FinancialPortfolio.Services.Orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        
        Task<Order> GetAsync(Guid id);
        
        Task<IEnumerable<Order>> GetAllAsync(SearchOptions search);
    }
}