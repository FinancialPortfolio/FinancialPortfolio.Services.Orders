using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.EventHandlers.Assets
{
    public class StocksCreatedEventHandler : IEventHandler<StocksCreatedEvent>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StocksCreatedEventHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        
        public async Task HandleAsync(StocksCreatedEvent @event, MessagePayload payload)
        {
            var assets = _mapper.Map<IEnumerable<Stock>>(@event.Stocks);
            await _stockRepository.CreateManyAsync(assets);
        }
    }
}