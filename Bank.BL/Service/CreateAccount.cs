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
        public Account account;
        public Customer customer;
        public Account Creating(string firstName, string lastName, DateTime birthDate, double balance) 
        {
            int id = ++counter;
            customer = new Customer(id, firstName, lastName, birthDate);
            account = new Account(id, balance, (customer.FirstName + " " + customer.LastName));
            Console.WriteLine($"\nYour account was created!\nId: {account.Id}\nBalance: ${account.Balance}\nCreation date: {account.Created}");
            return account;
        }
    }
}
