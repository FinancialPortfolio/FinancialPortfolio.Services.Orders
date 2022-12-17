using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Entities.Assets;

namespace FinancialPortfolio.Services.Orders.Domain.Repositories
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> CreateManyAsync(IEnumerable<Asset> assets);
        
        Task<Asset> GetAsync(Guid id);
        
        Task<IEnumerable<Asset>> GetAllAsync(IEnumerable<string> symbols);
    }
}