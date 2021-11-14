using System;
using System.Threading.Tasks;
using FinancialPortfolio.Services.Orders.Domain.Entities;

namespace FinancialPortfolio.Services.Orders.Domain.Repositories
{
    public interface IAssetRepository
    {
        Task<Asset> CreateAsync(Asset asset);
        
        Task<Asset> GetAsync(Guid id);
    }
}