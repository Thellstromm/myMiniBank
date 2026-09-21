using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace myMiniBank
{
    class BankUi
    {
        private readonly BankAccount _account;
        public BankUi(BankAccount account)
        {
            _account = account;

        }

        public void WriteSlowly(string text, int delayMs = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }
        public void ShowMenu()
        {
            Console.WriteLine();
            WriteSlowly("=== myMiniBank ===");
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
                WriteSlowly($"Deposited {amount:F2} EUR. New balance: {_account.Balance:F2} EUR");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public void HandleWithdraw()
        {
            Console.Write("Enter amount to Withdrwal: ");
            string input = Console.ReadLine() ?? "";
            decimal amount;

            if(!decimal.TryParse(input, out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }
            try
            {
                _account.Withdraw(amount);
                WriteSlowly($"Withdrewed {amount:F2} EUR. New balance: {_account.Balance:F2} EUR");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
        }
        public void ShowBalance()
        {
            WriteSlowly($"{_account.Balance:F2} EUR");
        }


    }
}
