namespace myMiniBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set console output encoding to UTF-8 so that special characters like € are displayed correctly
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var account = new BankAccount("12345");

            account.Deposit(1000);
            account.Withdraw(200);

            Console.WriteLine($"Balance: {account.Balance} €");
        }

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
}
