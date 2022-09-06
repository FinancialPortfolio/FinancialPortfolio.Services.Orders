using System;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Exceptions
{
    public class InvalidAccountIdException : Exception
    {
        public InvalidAccountIdException(string message) : base(message)
        {
        }
    }
}