using System;

namespace Bank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            Console.WriteLine("We are welcome you in RS Bank!");

            while (true)
            {
                menu.MenuSwitch(0);

                if (menu.Choose == 1)
                {
                    menu.MenuSwitch(1);
                    if(menu.Choose == 2) 
                    {
                        Console.Clear();
                        continue;
                    }
                }

                else if (menu.Choose == 2) 
                {
                    menu.MenuSwitch(2);
                    if (menu.Choose == 2) 
                    {
                        Console.Clear();
                        continue;
                    }
                }
                break;
            }
        }   
    }
}