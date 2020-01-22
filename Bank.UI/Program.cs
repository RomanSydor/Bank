using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.BL.Model;
using Bank.BL.Service;

namespace Bank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            GetCustomerInfo customerInfo = new GetCustomerInfo();
            CreateAccount createAccount = new CreateAccount();

            Console.Write(menu.Greeting);
            bool check;
            do
            {
        start:  Console.WriteLine(menu.Services);
                menu.Choose = Console.ReadLine();
                if (int.TryParse(menu.Choose, out int result) && result >= 1 && result <= 4)
                {
                    Console.WriteLine($"Your choice: {result}");
                    check = false;
                    switch (menu.Choose) 
                    {
                        case "1":
                            customerInfo.GetInfo();
                            createAccount.Creating(customerInfo.firstName, customerInfo.lastName, customerInfo.birthDate, 0.0); // TODO fix bag with top upping
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
                            Console.Write(menu.TopUpString);
                            menu.TopUp = double.Parse(Console.ReadLine()); // TODO check top up input
                            //createAccount.account.IncreaseBalance(menu.TopUp);
                            //Console.WriteLine($"Owner: {createAccount.account.Owner}\nYour balance: ${createAccount.account.Balance}");
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
