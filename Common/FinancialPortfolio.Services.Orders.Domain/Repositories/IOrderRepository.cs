using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPortfolio.Search;
using FinancialPortfolio.Search.Pagination;
using FinancialPortfolio.Services.Orders.Domain.Entities;

namespace FinancialPortfolio.Services.Orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        
        Task<IEnumerable<Order>> CreateManyAsync(IEnumerable<Order> orders);
        
        Task<bool> UpdateAsync(Order order);
        
        Task DeleteAsync(Guid id);
        
        Task<Order> GetAsync(Guid id);
        
        Task<PaginationResult<Order>> GetAllAsync(SearchOptions search);
    }
}