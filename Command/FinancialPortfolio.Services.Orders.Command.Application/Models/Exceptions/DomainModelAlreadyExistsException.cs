using System;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions
{
    public class DomainModelAlreadyExistsException : Exception
    {
        public DomainModelAlreadyExistsException(string message) : base(message)
        {
        }
    }
}