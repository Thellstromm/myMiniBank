namespace myMiniBank
{
    class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        private readonly List<Transaction> _transactions = new();
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();
        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater then zero");
            }

            Balance += amount;
            _transactions.Add(new Transaction(amount, "Deposit"));
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                throw new ArgumentException("Inavlid withdrawal");
            }

            Balance -= amount;
            _transactions.Add(new Transaction(-amount, "Withdrawl"));
        }

        

    }
}