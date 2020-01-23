using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UI
{
    public class GetCustomerInfo
    {
        public string FirstName;
        public string LastName;
        public DateTime BirthDate;
        public double StartBalance;
        public void GetInfo() 
        {
            Console.Write("Input your first name: ");
            FirstName = Console.ReadLine();
            Console.Write("Input your last name: ");
            LastName = Console.ReadLine();
            Console.Write("Input date of your birth(mm.dd.yyyy): ");
            BirthDate = DateTime.Parse(Console.ReadLine()); // TODO add TryParse to dataTime
            Console.Write("Start top up: $");
            StartBalance = double.Parse(Console.ReadLine());
        }
    }
}
