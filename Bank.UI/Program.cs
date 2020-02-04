using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.BL.Model;
using Bank.BL;

namespace Bank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Account account = new Account();
            Customer customer = new Customer();
            BankEvents events = new BankEvents();
            AccountController controller = new AccountController();

            while (true)
            {
                Console.WriteLine("We are welcome you in RS Bank!");
                Console.Write(menu.LogIn);
                menu.Choose = ParseDouble(1, 2);

                if (menu.Choose == 1)
                {
                    while (true)
                    {
                        try
                        {
                            events.accounts = controller.Load();
                            Console.Write("Input account id: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Input your password: ");
                            string password = Console.ReadLine();
                            Console.Clear();
                            events.FindAccount(id, password);
                            Console.WriteLine("\n" + menu.Services);
                            menu.Choose = ParseDouble(1, 5);
                            menu.MenuSwitch();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!\n");
                            continue;
                        }
                        break;
                    }
                }
                else if (menu.Choose == 2)
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("_Registration_");
                            events.OpenAccount();
                            controller.Save(events.accounts);
                            Console.WriteLine("\n" + menu.Services);
                            menu.Choose = ParseDouble(1, 5);
                            menu.MenuSwitch();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!\n");
                            continue;
                        }
                        break;
                    }
                }
                break;
            }
            Console.ReadLine();
        }

        private static double ParseDouble(int from, int to)
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value) && (value >= from && value <= to))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid input, try again!");
                }
            }
        }
    }
}