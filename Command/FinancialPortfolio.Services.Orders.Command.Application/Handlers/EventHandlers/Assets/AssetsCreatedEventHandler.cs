using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Assets.Asset;
using FinancialPortfolio.Services.Orders.Domain.Entities.Assets;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.EventHandlers.Assets
{
    public class AssetsCreatedEventHandler : IEventHandler<AssetsCreatedEvent>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public AssetsCreatedEventHandler(IAssetRepository assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }
        
        public async Task HandleAsync(AssetsCreatedEvent @event, MessagePayload payload)
        {
            var assets = _mapper.Map<IEnumerable<Asset>>(@event.Assets);
            await _assetRepository.CreateManyAsync(assets);
        }
    }
}