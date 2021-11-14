using System;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions
{
    public class DomainModelNotExistsException : Exception
    {
        public DomainModelNotExistsException(string message) : base(message)
        {
        }
    }
}