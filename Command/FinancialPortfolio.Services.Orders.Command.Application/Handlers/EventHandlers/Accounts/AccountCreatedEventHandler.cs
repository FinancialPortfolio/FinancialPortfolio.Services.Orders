using System.Threading.Tasks;
using FinancialPortfolio.CQRS.Events;
using FinancialPortfolio.Messaging.Models;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Events.External.Accounts;
using FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions;
using FinancialPortfolio.Services.Orders.Domain.Entities;
using FinancialPortfolio.Services.Orders.Domain.Repositories;

namespace FinancialPortfolio.Services.Orders.Command.Application.Handlers.EventHandlers.Accounts
{
    public class AccountCreatedEventHandler : IEventHandler<AccountCreatedEvent>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountCreatedEventHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        public async Task HandleAsync(AccountCreatedEvent @event, MessagePayload payload)
        {
            var existingAccount = await _accountRepository.GetAsync(@event.Id);
            if (existingAccount != null)
                throw new DomainModelAlreadyExistsException($"Account with id: {@event.Id} already exists");
            
            var account = new Account(@event.Id, @event.Name);
            await _accountRepository.CreateAsync(account);
        }
    }
}