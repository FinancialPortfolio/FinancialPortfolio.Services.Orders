using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.Services.Orders.Domain.Repositories;
using Grpc.Core;
using OrderApi;

namespace FinancialPortfolio.Services.Orders.Query.Application.Services
{
    public class OrderService : Order.OrderBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        
        public override async Task<OrdersResponse> GetAll(GetOrdersRequest request, ServerCallContext context)
        {
            var orders = await _orderRepository.GetAllAsync();

            var orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            var response = new OrdersResponse
            {
                Orders = { orderResponses }
            };

            return response;
        }
    }
}