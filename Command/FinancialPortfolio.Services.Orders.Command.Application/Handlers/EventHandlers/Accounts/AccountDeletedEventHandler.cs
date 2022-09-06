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

        public AccountDeletedEventHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task HandleAsync(AccountDeletedEvent message, MessagePayload payload)
        {
            var account = await _accountRepository.GetAsync(message.Id);
            if (account is null)
                return;

            await _accountRepository.DeleteAsync(account.Id);
        }
    }
}