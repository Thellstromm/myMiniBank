namespace myMiniBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set console output encoding to UTF-8 so that special characters like € are displayed correctly
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            BankAccount account = new BankAccount("12345");
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

