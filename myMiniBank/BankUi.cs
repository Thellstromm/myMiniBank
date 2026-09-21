using System;
using System.Collections.Generic;
using System.Text;

namespace myMiniBank
{
    class BankUi
    {
        private readonly BankAccount _account;
        public BankUi(BankAccount account)
        {
            _account = account;

        }
        public void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== myMiniBank ===");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("q. Quit");
            Console.Write("Choose: ");
           
        }

        public string ReadChoice()
        {
            return Console.ReadLine() ?? "";

        }

        public void HandleDeposir()
        {
            Console.Write("Enter amount to deposit: ");
            string input = Console.ReadLine() ?? "";

            decimal amount;

            if (!decimal.TryParse(input, out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            try
            {
                _account.Deposit(amount);
                Console.WriteLine($"Deposited {amount:F2} EUR. New balance: {_account.Balance:F2} EUR");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

    }
}
