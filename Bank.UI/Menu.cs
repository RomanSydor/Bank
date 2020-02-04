using Bank.BL;
using Bank.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UI
{
    public class Menu
    {
        public string Services { get; } = "1)Top up your account;\n2)Withdraw money;\n3)Close accuont;\n4)Show account info;\n5)Exit;";
        public string LogIn { get; } = "Log in:\n1)Sign in\n2)Registrate\n";
        public string ReturnToMenu { get; } = "\nDo you want to return to the menu?\n1)yes\n2)no";
        public double Sum { get; set; }
        public double Choose { get; set; }

        Account account = new Account();
        Customer customer = new Customer();
        BankEvents events = new BankEvents();
        AccountController controller = new AccountController();

        public void MenuSwitch() 
        {
            switch (Choose) //TODO: fix bug with account null!!!
            {
                case 1:
                    while (true)
                    {
                        try
                        {
                            Console.Write("Input amount of replenishment: $");
                            Sum = double.Parse(Console.ReadLine());
                            events.TopUpAccount(Sum, account.Id);
                            controller.Save(events.accounts);
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
                            events.WithdrawMoney(Sum, account.Id);
                            controller.Save(events.accounts);
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
                case 3:
                    while (true)
                    {
                        try
                        {
                            events.DeleteAccount(account.Id);
                            controller.Save(events.accounts);
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
                            events.FindAccount(account.Id, account.Password);
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
                    controller.Save(events.accounts);
                    break;
            }
        }
    }
}