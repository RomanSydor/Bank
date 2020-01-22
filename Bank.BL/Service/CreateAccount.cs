using Bank.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BL.Service
{
    public class CreateAccount
    {
        static int counter = 0;
        public Account Creating(string firstName, string lastName, DateTime birthDate) 
        {
            int id = ++counter;
            Customer customer = new Customer(id, firstName, lastName, birthDate);
            Account account = new Account(id, 0.0, (customer.FirstName + " " + customer.LastName));
            Console.WriteLine($"\nYour account was created!\nId: {account.Id}\nBalance: ${account.Balance}\nCreation date: {account.Created}");
            return account;
        }
    }
}
