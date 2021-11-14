using System;
using System.Threading.Tasks;
using FinancialPortfolio.Services.Orders.Domain.Entities;

namespace FinancialPortfolio.Services.Orders.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> CreateAsync(Account account);
        
        Task<Account> GetAsync(Guid id);
    }
}