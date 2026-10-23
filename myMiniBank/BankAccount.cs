namespace myMiniBank
{
    class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        private readonly List<Transaction> _transactions = new();
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();
        private readonly TransactionRepository _repository;

        public BankAccount(string accountNumber, TransactionRepository repository)
        {
            AccountNumber = accountNumber;
            _repository = repository;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero");
            }

            decimal newBalance = Balance + amount;
            Transaction transaction = new Transaction(amount, "Deposit");

            _repository.Save(transaction, newBalance);

            Balance = newBalance;
            _transactions.Add(transaction);
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                throw new ArgumentException("Invalid withdrawal");
            }

            decimal newBalance = Balance - amount;
            Transaction transaction = new Transaction(-amount, "Withdraw");

            _repository.Save(transaction, newBalance);

            Balance = newBalance;
            _transactions.Add(transaction);
        }

        public void LoadTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            Balance += transaction.Amount;
        }

        

    }
}