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

            Console.Write(menu.Greeting);
            Console.WriteLine(menu.Services);
            bool check;
            do
            {
                menu.Choose = Console.ReadLine();
                if (int.TryParse(menu.Choose, out int result) && result >= 1 && result <= 4)
                {
                    Console.WriteLine($"Your choice: {result}");
                    check = false;
                    switch (menu.Choose) 
                    {
                        case "1":
                            GetCustomerInfo customerInfo = new GetCustomerInfo();
                            CreateAccount account = new CreateAccount();
                            customerInfo.GetInfo();
                            account.Creating(customerInfo.firstName, customerInfo.lastName, customerInfo.birthDate);
                            break;
                    }
                }
                else
                {
                    Console.Write("Invalid input!\nPleace, repeat: ");
                    check = true;
                }
            } while (check);
            Console.ReadLine();
        }
    }
}
