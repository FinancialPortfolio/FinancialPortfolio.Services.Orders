using System;
using FinancialPortfolio.Services.Orders.Domain.Enums;

namespace FinancialPortfolio.Services.Orders.Command.Application.Models.Commands
{
    public record IntegrateOrderCommand
    {
        public OrderType Type { get; }
        
        public double Amount { get; }
        
        public decimal Price { get; }
        
        public DateTime DateTime { get; }
        
        public decimal Commission { get; }
        
        public string Symbol { get; }

        public IntegrateOrderCommand(OrderType type, double amount, decimal price, DateTime dateTime, decimal commission, string symbol)
        {
            Type = type;
            Amount = amount;
            Price = price;
            DateTime = dateTime;
            Commission = commission;
            Symbol = symbol;
        }
    }
}