using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.BL;

namespace Bank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = false;
            Menu menu = new Menu();
            
            Console.Write(menu.Greeting);
            Console.WriteLine(menu.Services);
            do
            {
                menu.Choose = Console.ReadLine();
                if (int.TryParse(menu.Choose, out int result))
                {
                    Console.WriteLine($"Your choice: {menu.Choose}");
                    check = false;
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
