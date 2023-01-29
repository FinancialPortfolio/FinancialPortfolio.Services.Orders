using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.Search;
using FinancialPortfolio.Services.Orders.Domain.Repositories;
using FinancialPortfolio.Services.Orders.Query.Application.Models.Exceptions;
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
        
        public override async Task<OrderResponse> Get(GetOrderQuery request, ServerCallContext context)
        {
            var id = Guid.Parse(request.Id);
            var accountId = Guid.Parse(request.AccountId);
            
            var order = await _orderRepository.GetAsync(id);
            if (order is null)
                throw new DomainModelNotExistsException($"Order with id: {request.Id} doesn't exist.");

            if (order.AccountId != accountId)
                throw new DomainModelNotExistsException($"Order with id: {request.Id} and accountId: {request.AccountId} doesn't exist.");
            
            var response = _mapper.Map<OrderResponse>(order);
            
            return response;
        }
        
        public override async Task<OrdersResponse> GetAll(GetOrdersQuery request, ServerCallContext context)
        {
            var search = _mapper.Map<SearchOptions>(request.Search);
            var ordersResult = await _orderRepository.GetAllAsync(search);

            var orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(ordersResult.Documents);
            var response = new OrdersResponse
            {
                Orders = { orderResponses },
                TotalCount = ordersResult.TotalCount
            };

            return response;
        }
    }
}