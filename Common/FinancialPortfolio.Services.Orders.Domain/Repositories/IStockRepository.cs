using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPortfolio.Services.Orders.Domain.Entities;

namespace FinancialPortfolio.Services.Orders.Domain.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> CreateManyAsync(IEnumerable<Stock> assets);
        
        Task<Stock> GetAsync(Guid id);
    }
}