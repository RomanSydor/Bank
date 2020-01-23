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
            GetCustomerInfo customerInfo = new GetCustomerInfo();
            
            Console.Write(menu.Greeting);
            bool check;
            do
            {
        start:  Console.WriteLine(menu.Services);
                menu.Choose = Console.ReadLine();
                if (int.TryParse(menu.Choose, out int result) && result >= 1 && result <= 4)
                {
                    Console.WriteLine($"\nYour choice: {result}\n");
                    check = false;
                    switch (menu.Choose) 
                    {
                        case "1":
                            Console.WriteLine("_Registration_");
                            customerInfo.GetInfo();
                            Customer customer = new Customer(customerInfo.FirstName, customerInfo.LastName, customerInfo.BirthDate);
                            Account account = new Account(customerInfo.StartBalance, (customer.FirstName + " " + customer.LastName));
                            Console.WriteLine($"\nAccount was created!\n{customer.ToString()}\n\n{account.ToString()}");
                            
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
                            Console.Write("Input amount of top up: ");
                            menu.TopUp = double.Parse(Console.ReadLine()); // TODO check top up inpup
                            
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
