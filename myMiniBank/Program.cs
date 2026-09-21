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

                if (userChoice == "q" || userChoice == "Q")
                {
                    break;
                }
                else if (userChoice == "1")
                {
                    ui.HandleDeposir();
                }
                else if (userChoice == "2")
                {
                    ui.HandleWithdraw();
                }


            }
        }

    }




}

