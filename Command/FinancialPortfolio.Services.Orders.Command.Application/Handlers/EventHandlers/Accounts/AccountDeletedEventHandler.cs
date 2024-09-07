using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Accounts;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.EventHandlers.Accounts
{
    public class AccountDeletedEventHandler : IEventHandler<AccountDeletedEvent>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOrderRepository _orderRepository;

        public AccountDeletedEventHandler(IAccountRepository accountRepository, IOrderRepository orderRepository)
        {
            _accountRepository = accountRepository;
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(AccountDeletedEvent message, MessagePayload payload)
        {
            var account = await _accountRepository.GetAsync(message.Id);
            if (account is null)
                return;

            await _accountRepository.DeleteAsync(account.Id);

            await _orderRepository.DeleteAllAsync(account.Id);
        }
    }
}