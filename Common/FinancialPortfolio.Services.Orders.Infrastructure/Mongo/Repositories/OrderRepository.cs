using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.Mongo.Repositories;
using FinancialPortfolio.Search;
using FinancialPortfolio.Search.Pagination;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Repositories;
using FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Documents;

namespace FinancialPortfolio.Services.Orders.Infrastructure.Mongo.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IBaseRepository<OrderDocument> _baseRepository;
        private readonly IMapper _mapper;

        public OrderRepository(IBaseRepository<OrderDocument> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        
        public async Task<Order> CreateAsync(Order order)
        {
            var orderDocument = _mapper.Map<OrderDocument>(order);
            var createdDocument = await _baseRepository.CreateAsync(orderDocument);
            
            return _mapper.Map<Order>(createdDocument);
        }

        public async Task<Order> GetAsync(Guid id)
        {
            var orderDocument = await _baseRepository.GetAsync(id);
            return _mapper.Map<Order>(orderDocument);
        }
        
        public async Task<PaginationResult<Order>> GetAllAsync(SearchOptions search)
        {
            var documentsResult = await _baseRepository.GetAllAsync(search);
            var orders = _mapper.Map<IEnumerable<Order>>(documentsResult.Documents);

            return new PaginationResult<Order>(orders, documentsResult.TotalCount);
        }
    }
}