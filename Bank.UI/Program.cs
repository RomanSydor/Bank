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
               // Console.WriteLine(menu.LogIn);

        start:  Console.WriteLine(menu.Services);
                menu.Choose = Console.ReadLine();
                Console.Clear();
                if (int.TryParse(menu.Choose, out int result) && result >= 1 && result <= 6)
                {
                    Console.WriteLine($"Your choice: {result}\n");
                    check = false;
                    switch (menu.Choose) 
                    {
                        case "1":
                            try 
                            { 
                            Console.WriteLine("_Registration_");
                            events.OpenAccount();
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid format!");
                            }

                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                Console.Clear();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Thanks for choosing us, bye!");
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
                                menu.Sum = double.Parse(Console.ReadLine());
                                events.TopUpAccount(menu.Sum, id);
                            }
                            catch (FormatException) 
                            {
                                Console.WriteLine("Invalid format!");
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Account wasn't found!");
                            }
                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                Console.Clear();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Thanks for choosing us, bye!");
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
                                menu.Sum = double.Parse(Console.ReadLine());
                                events.WithdrawMoney(menu.Sum, id);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid format!");
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Account wasn't found!");
                            }

                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                Console.Clear();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Thanks for choosing us, bye!");
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
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid format!");
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Account wasn't found!");
                            }

                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                Console.Clear();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Thanks for choosing us, bye!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input!\nPleace, repeat:");
                                    check = true;
                                }
                            } while (check);
                            break;

                        case "5":
                            try
                            {
                                Console.Write("Id: ");
                                int id = int.Parse(Console.ReadLine());
                                events.FindAccount(id);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid format!");
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Account wasn't found!");
                            }
                            do
                            {
                                Console.WriteLine(menu.ReturnToMenu);
                                menu.Choose = Console.ReadLine();
                                Console.Clear();
                                if (int.TryParse(menu.Choose, out int result1) && result1 >= 1 && result1 <= 2)
                                {
                                    check = false;
                                    if (menu.Choose == "1")
                                    {
                                        goto start;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Thanks for choosing us, bye!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input!\nPleace, repeat:");
                                    check = true;
                                }
                            } while (check);
                            break;
                        case "6":
                            Console.WriteLine("Thanks for choosing us, bye!");
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

        //private static DateTime ParseDateTime(string value)
        //{
        //    DateTime birthDate;
        //    while (true)
        //    {
        //        Console.Write($"Input {value} (mm.dd.yyyy): ");
        //        if (DateTime.TryParse(Console.ReadLine(), out birthDate))
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Неверный формат {value}");
        //        }
        //    }

        //    return birthDate;
        //}
    }
}