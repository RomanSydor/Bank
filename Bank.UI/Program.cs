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

            Console.Write(menu.Greeting);
            bool check;
            do
            {
        start:  Console.WriteLine(menu.Services);
                menu.Choose = Console.ReadLine();
                if (int.TryParse(menu.Choose, out int result) && result >= 1 && result <= 5)
                {
                    Console.WriteLine($"\nYour choice: {result}\n");
                    check = false;
                    switch (menu.Choose) 
                    {
                        case "1":
                            Console.WriteLine("_Registration_");
                            events.OpenAccount();

                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input!\nPleace, repeat:");
                                    check = true;
                                }
                            } while (check);
                            break;
                        
                        case "2":
                            
                            try
                            {
                                Console.Write("Id: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.Write("Input amount of replenishment: $");
                                menu.Sum = double.Parse(Console.ReadLine()); // TODO check top up input
                                events.TopUpAccount(menu.Sum, id);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Account wasn't found!");
                            }
                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input!\nPleace, repeat:");
                                    check = true;
                                }
                            } while (check);
                            break;
                       
                        case "3":
                            
                            try
                            {
                                Console.Write("Id: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.Write("Input the output amount: $");
                                menu.Sum = double.Parse(Console.ReadLine()); // TODO check output input
                                events.WithdrawMoney(menu.Sum, id);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Account wasn't found!");
                            }

                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input!\nPleace, repeat:");
                                    check = true;
                                }
                            } while (check);
                            break;
                     
                        case "4":
                             
                            try
                            {
                                Console.Write("Id: ");
                                int id = int.Parse(Console.ReadLine());
                                events.DeleteAccount(id);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Account wasn't found!");
                            }

                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input!\nPleace, repeat:");
                                    check = true;
                                }
                            } while (check);
                            break;

                        case "5":// TODO fix issue with account review
                            try
                            {
                                Console.Write("Id: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine(events.accounts[id].ToString());
                            }
                            catch (IndexOutOfRangeException) 
                            {
                                Console.WriteLine("Account wasn't found!");
                            }
                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input!\nPleace, repeat:");
                                    check = true;
                                }
                            } while (check);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input!\nPleace, repeat:");
                    check = true;
                }
            } while (check);
            Console.ReadLine();
         }
    }
}
