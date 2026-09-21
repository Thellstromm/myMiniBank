using System;
using System.Collections.Generic;
using System.Text;

namespace myMiniBank
{
    class Transaction
    {
        public DateTime Timestamp { get; } = DateTime.Now;
        public decimal Amount { get; }
        public string Description { get; }

        public Transaction(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
            
        }
    }
}
