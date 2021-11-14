using System;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.Mongo.Repositories;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Repositories;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IBaseRepository<AccountDocument> _baseRepository;
        private readonly IMapper _mapper;

        public AccountRepository(IBaseRepository<AccountDocument> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        
        public async Task<Account> CreateAsync(Account account)
        {
            var accountDocument = _mapper.Map<AccountDocument>(account);
            var createdDocument = await _baseRepository.CreateAsync(accountDocument);
            
            return _mapper.Map<Account>(createdDocument);
        }

        public async Task<Account> GetAsync(Guid id)
        {
            var accountDocuments = await _baseRepository.GetAsync(id);
            return _mapper.Map<Account>(accountDocuments);
        }
    }
}