
using Microsoft.Data.SqlClient;

namespace myMiniBank

{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set console output encoding to UTF-8 so that special characters like € are displayed correctly
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string connectionString =
                @"Server=.\SQLEXPRESS02;Database=MyMiniBank;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            TransactionRepository repository = new TransactionRepository(connectionString);

            BankAccount account = new BankAccount("12345", repository);

            try
            {
                List<Transaction> transactions = repository.GetAll();

                foreach (Transaction transaction in transactions)
                {
                    account.LoadTransaction(transaction);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Could not load account data from the database.");
                Console.WriteLine($"Technical information: {ex.Message}");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            
            BankUi ui = new BankUi(account);


            while (true)
            {
                ui.ShowMenu();
                string userChoice = ui.ReadChoice();

                switch (userChoice)
                {
                    case "1":
                        ui.HandleDeposir();
                        break;
                    case "2":
                        ui.HandleWithdraw();
                        break;
                    case "3":
                        ui.ShowBalance();
                        break;
                    case "4":
                        ui.ShowTransactions();
                        break;
                    case "q":
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }


            }
        }

    }




}

