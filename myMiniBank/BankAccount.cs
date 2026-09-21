namespace myMiniBank
{
    class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
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
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                throw new ArgumentException("Inavlid withdrawal");
            }

            Balance -= amount;
        }
    }
}