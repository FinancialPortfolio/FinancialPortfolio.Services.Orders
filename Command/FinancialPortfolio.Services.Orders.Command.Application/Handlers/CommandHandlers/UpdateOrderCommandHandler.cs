using System.Linq;
using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Commands;
using FinancialPortfolio.DDD;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Commands;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.CommandHandlers
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IStockRepository stockRepository, IDomainEventPublisher domainEventPublisher)
        {
            _orderRepository = orderRepository;
            _stockRepository = stockRepository;
            _domainEventPublisher = domainEventPublisher;
        }
        
        public async Task HandleAsync(UpdateOrderCommand message, MessagePayload payload)
        {
            var order = await _orderRepository.GetAsync(message.Id);
            if (order is null)
                throw new DomainModelNotExistsException($"Order with id: {message.Id} doesn't exist.");
            
            var existingAsset = await _stockRepository.GetAsync(message.AssetId);
            if (existingAsset is null)
                throw new DomainModelNotExistsException($"Asset with id: {message.AssetId} doesn't exist");

            if (order.AccountId != message.AccountId)
                throw new InvalidAccountIdException($"Order with id: {message.Id} doesn't belong to account {message.AccountId}.");
            
            order.Update(message.Type, message.Amount, message.Price, message.DateTime, message.Commission, message.AssetId);
            
            var updateResult = await _orderRepository.UpdateAsync(order);
            if (!updateResult)
                throw new DomainModelNotUpdatedException($"Order with id: {message.Id} wasn't updated. Version: {order.Version}.");

            await _domainEventPublisher.PublishAsync(order.Events.ToList());
        }
    }
}