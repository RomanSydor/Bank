using Bank.BL;
using Bank.BL.Model;
using System;

namespace Bank.UI
{
    /// <summary>
    /// Realised user interface
    /// </summary>
    public class Menu
    {
        public string Services { get; } = "1)Top up your account;\n2)Withdraw money;\n3)Close accuont;\n4)Show account info;\n5)Exit;";
        public string LogIn { get; } = "Log in:\n1)Sign in\n2)Registrate\n3)Exit\n";
        public string MenuOrExit { get; } = "\n1)Menu\n2)Log out\n3)Exit";
        public string Password { get; set; }
        public double Sum { get; set; }
        public int Choose { get; set; }
        public bool FindAccount { get; set; }

        public Account account = BankEvents.Account;
        public Account[] accounts = BankEvents.accounts;
        public BankEvents events = new BankEvents();
        
        /// <summary>
        /// Realised choosing of services interface
        /// </summary>
        /// <param name="choose"></param>
        public void ServiceSwitch(int choose)
        {
            switch (choose)
            {
                case 1: //Input money
                    while (true)
                    {
                        try
                        {
                            Console.Write("Input amount of replenishment: $");
                            Sum = double.Parse(Console.ReadLine());
                            account = events.InputMoney(Sum, account.Id);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid format, try again!");
                            continue;
                        }
                        break;
                    }
                    break;
                case 2: // Output money
                    while (true)
                    {
                        try
                        {
                            Console.Write("Input the output amount: $");
                            Sum = double.Parse(Console.ReadLine());
                            account = events.OutputMoney(Sum, account.Id);
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
                case 4: // Find account and show account info
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
                case 5: // Close app
                    events.EndSession();
                    break;
                case 6: // Create account
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
                case 7: //Sing in
                    while (true)
                    {
                        try
                        {
                            Console.Write("Input account id: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Input your password: ");
                            string password = Console.ReadLine();
                            account = events.FindAccount(id, password);
                            if (account.Owner == null)
                            {
                                FindAccount = false;
                            }
                            else
                            {
                                FindAccount = true;
                            }
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
        
        /// <summary>
        /// Realised start screen menu interface
        /// </summary>
        /// <param name="choose"></param>
        public void MenuSwitch(int choose)
        {
            switch (choose)
            {
                case 0: // log in
                    Console.Write(LogIn);
                    Choose = ParseInt(1, 3);
                    break;
                case 1: // sing in menu
                    while (true)
                    {
                        ServiceSwitch(7);
                        if (FindAccount)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("\n" + Services);
                        Choose = ParseInt(1, 5);
                        ServiceSwitch(Choose);
                        Console.WriteLine(MenuOrExit);
                        Choose = ParseInt(1, 3);
                        if(Choose == 1) 
                        {
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case 2: // registration menu
                    while (true)
                    {
                        Console.WriteLine("_Registration_");
                        ServiceSwitch(6);
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("\n" + Services); //TODO: to fix bug with id = 0
                        Choose = ParseInt(1, 5);
                        ServiceSwitch(Choose);
                        Console.WriteLine(MenuOrExit);
                        Choose = ParseInt(1, 3);
                        if (Choose == 1)
                        {
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Realised checking of int input
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static int ParseInt(int from, int to)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && (value >= from && value <= to))
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