using System;
using System.Collections.Generic;
using System.Text;

namespace myMiniBank
{
    class Transaction
    {
        public DateTime Timestamp { get; }
        public decimal Amount { get; }
        public string Description { get; }

        public Transaction(decimal amount, string description, DateTime? timestamp = null)
        {
            Amount = amount;
            Description = description;
            Timestamp = timestamp ?? DateTime.Now;
            
        }
    }
}
