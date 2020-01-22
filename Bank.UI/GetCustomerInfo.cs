using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UI
{
    public class GetCustomerInfo
    {
        public string firstName;
        public string lastName;
        public DateTime birthDate;
        public void GetInfo() 
        {
            Console.Write("Input your first name: ");
            firstName = Console.ReadLine();
            Console.Write("Input your last name: ");
            lastName = Console.ReadLine();
            Console.Write("Input date of your birth(mm.dd.yyyy): ");
            birthDate = DateTime.Parse(Console.ReadLine()); // TODO add TryParse
        }
    }
}
