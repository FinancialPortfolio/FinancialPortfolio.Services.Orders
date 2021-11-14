using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.Mongo.Repositories;
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

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orderDocuments = await _baseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Order>>(orderDocuments);
        }
    }
}