using Bank.BL;
using Bank.BL.Model;
using System;

namespace Bank.UI
{
    public class Menu
    {
        public string Services { get; } = "1)Top up your account;\n2)Withdraw money;\n3)Close accuont;\n4)Show account info;\n5)Exit;";
        public string LogIn { get; } = "Log in:\n1)Sign in\n2)Registrate\n";
        public string ReturnToMenu { get; } = "\nDo you want to return to the menu?\n1)yes\n2)no";
        public string Password { get; set; }
        public double Sum { get; set; }
        public int Choose { get; set; }

        public Account account = BankEvents.Account;
        public Account[] accounts = BankEvents.accounts;
        public BankEvents events = new BankEvents();
        //public AccountController controller = new AccountController();

        public void MenuSwitch(int choose)
        {
            // accounts = controller.Load();
            switch (choose)
            {
                case 1:
                    while (true)
                    {
                        try
                        {
                        //    Console.WriteLine("Input password:");
                        //    Password = Console.ReadLine();
                            Console.Write("Input amount of replenishment: $");
                            Sum = double.Parse(Console.ReadLine());
                            account = events.TopUpAccount(Sum, account.Id);
                            //controller.Save(accounts);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!");
                            continue;
                        }
                        break;
                    }
                    break;
                case 2:
                    while (true)
                    {
                        try
                        {
                            Console.Write("Input the output amount: $");
                            Sum = double.Parse(Console.ReadLine());
                            account = events.WithdrawMoney(Sum, account.Id);
                            //controller.Save(accounts);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!");
                            continue;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Account wasn't found!");
                            continue;
                        }
                        break;
                    }
                    break;
                case 3:// TODO deletig feature
                    while (true)
                    {
                        try
                        {
                            events.DeleteAccount(account.Id);
                            //controller.Save(accounts);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!");
                            continue;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Account wasn't found!");
                            continue;
                        }
                        break;
                    }
                    break;
                case 4:
                    while (true)
                    {
                        try
                        {
                            account = events.FindAccount(account.Id, account.Password);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!");
                            continue;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Account wasn't found!");
                            continue;
                        }
                        break;
                    }
                    break;
                case 5:
                    Console.WriteLine("Thanks for choosing us, bye!");
                    events.EndSession();
                    //controller.Save(accounts);
                    break;
                case 6:
                    while (true)
                    {
                        try
                        {
                            events.OpenAccount();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!");
                            continue;
                        }
                        break;
                    }
                    break;
                case 7:
                    while (true)
                    {
                        try
                        {
                            Console.Write("Input account id: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Input your password: ");
                            string password = Console.ReadLine();
                            Console.Clear();
                            account = events.FindAccount(id, password);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!\n");
                            continue;
                        }
                        break;
                    }
                    break;
            }
        }
    }
}