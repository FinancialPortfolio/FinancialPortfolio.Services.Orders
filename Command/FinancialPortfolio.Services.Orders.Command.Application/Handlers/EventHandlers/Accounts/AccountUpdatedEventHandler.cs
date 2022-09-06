using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Accounts;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.EventHandlers.Accounts
{
    public class AccountUpdatedEventHandler : IEventHandler<AccountUpdatedEvent>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountUpdatedEventHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task HandleAsync(AccountUpdatedEvent message, MessagePayload payload)
        {
            var account = await _accountRepository.GetAsync(message.Id);
            if (account is null)
                throw new DomainModelNotExistsException($"Account with id: {message.Id} doesn't exist.");

            account.Update(message.Name, message.Version);
			
            var updateResult = await _accountRepository.UpdateAsync(account);
            if (!updateResult)
                throw new DomainModelNotUpdatedException($"Account with id: {message.Id} wasn't updated. Version: {account.Version}.");
        }
    }
}