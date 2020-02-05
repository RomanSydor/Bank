using Bank.BL;
using System;

namespace Bank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            while (true)
            {
                Console.WriteLine("We are welcome you in RS Bank!");
                Console.Write(menu.LogIn);
                menu.Choose = ParseInt(1, 2);

                if (menu.Choose == 1)
                {
                    while (true)
                    {
                        menu.MenuSwitch(7);
                        Console.WriteLine("\n" + menu.Services);
                        menu.Choose = ParseInt(1, 5);
                        menu.MenuSwitch(menu.Choose);
                        break;
                    }
                }
                else if (menu.Choose == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("_Registration_");
                        menu.MenuSwitch(6);
                        Console.WriteLine("\n" + menu.Services); //TODO: to fix bug with id = 0
                        menu.Choose = ParseInt(1, 5);
                        menu.MenuSwitch(menu.Choose);
                        break;
                    }
                }
                break;
            }
            Console.ReadLine();
        }

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