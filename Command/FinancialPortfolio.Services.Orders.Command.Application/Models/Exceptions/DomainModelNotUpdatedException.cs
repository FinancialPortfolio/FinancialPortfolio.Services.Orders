using System;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions
{
    public class DomainModelNotUpdatedException : Exception
    {
        public DomainModelNotUpdatedException(string message) : base(message)
        {
        }
    }
}