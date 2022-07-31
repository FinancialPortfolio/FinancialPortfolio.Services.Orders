using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.EventHandlers
{
    public class AssetCreatedEventHandler : IEventHandler<AssetCreatedEvent>
    {
        private readonly IAssetRepository _assetRepository;

        public AssetCreatedEventHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }
        
        public async Task HandleAsync(AssetCreatedEvent @event, MessagePayload payload)
        {
            var existingAsset = await _assetRepository.GetAsync(@event.Id);
            if (existingAsset != null)
                throw new DomainModelAlreadyExistsException($"Asset with id: {@event.Id} already exists");
            
            var asset = new Asset(@event.Id, @event.Symbol, @event.Name);
            await _assetRepository.CreateAsync(asset);
        }
    }
}