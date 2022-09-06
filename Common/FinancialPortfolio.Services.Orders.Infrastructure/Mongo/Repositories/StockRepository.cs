using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.Mongo.Repositories;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Repositories;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IBaseRepository<StockDocument> _baseRepository;
        private readonly IMapper _mapper;

        public StockRepository(IBaseRepository<StockDocument> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<Stock>> CreateManyAsync(IEnumerable<Stock> stocks)
        {
            var stockDocuments = _mapper.Map<IEnumerable<StockDocument>>(stocks);
            var createdDocuments = await _baseRepository.CreateManyAsync(stockDocuments);
            
            return _mapper.Map<IEnumerable<Stock>>(createdDocuments);
        }
        
        public async Task<Stock> GetAsync(Guid id)
        {
            var stockDocument = await _baseRepository.GetAsync(id);
            return _mapper.Map<Stock>(stockDocument);
        }
    }
}