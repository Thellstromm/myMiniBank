using System;
using System.Collections.Generic;
using System.Security.Principal;
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
            Console.WriteLine("4. Show history");
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
            string input = ReadChoice();

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
            string input = ReadChoice();
            decimal amount;

            if (!decimal.TryParse(input, out amount) || amount <= 0)
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
            WriteSlowly($"{_account.Balance:N2} EUR");
        }

        public void ShowTransactions()
        {
            WriteSlowly("===Transaction history===");

            IReadOnlyList<Transaction> transactions = _account.Transactions;

            if (transactions.Count == 0)
            {
                Console.WriteLine("No tranasctions to show.");
            }
            else
            {
                decimal runningBalance = 0m;
                Console.WriteLine($"{"Date/Time",-16} | {"Description",-13} | {"Amount",25} | {"Balance",15}");
                Console.WriteLine(new string('-', 16) + "-|-" + new string('-', 13) + "-|-" + new string('-', 25) + "-|-" + new string('-', 15));

                foreach (Transaction t in transactions)
                {
                    runningBalance += t.Amount;
                    string amountStr = $"{t.Amount:N2} EUR";
                    string balanceStr = $"{runningBalance:N2} EUR";
                    Console.WriteLine($"{t.Timestamp:yyyy-MM-dd HH:mm} | {t.Description,-13} | {amountStr,25} | {balanceStr,15}");
                }
                
            }
        }


    }
}
