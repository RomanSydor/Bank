using Bank.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BL
{
    public class BankEvents
    {
        public Account Account = new Account();
        public Account[] accounts;

        public void OpenAccount()
        {        
            Console.Write("Input your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Input your last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Input date of your birth(mm.dd.yyyy): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine()); // TODO add TryParse to dataTime
            Console.Write("Start replenishment: $");
            double startBalance = double.Parse(Console.ReadLine());
            Console.Clear();
            Customer customer = new Customer(firstName, lastName, birthDate);
            Account account = new Account(startBalance, (customer.FirstName + " " + customer.LastName));
            if (account == null)
            {
                Console.WriteLine("\nError of creation account!");
            }
            else 
            {
                if (accounts == null)
                {
                    accounts = new Account[] { account };
                }
                else
                {
                    Account[] tempAccounts = new Account[accounts.Length + 1];
                    for (int i = 0; i < accounts.Length; i++)
                    {
                        tempAccounts[i] = accounts[i];
                        tempAccounts[tempAccounts.Length - 1] = account;
                    }
                    accounts = tempAccounts;
                }
            }
            Console.WriteLine($"Account was created!\n{customer.ToString()}\n\n{account.ToString()}");
        }
        public void TopUpAccount(double sum, int id) 
        {
            Account account = accounts[id];
            if (account == null) 
            {
                Console.WriteLine("Can't find account!");
            }
            else 
            {
                account.Balance += sum;
                Console.Clear();
                Console.WriteLine($"The balance was increased! \n{account.ToString()}\nTime: {DateTime.Now}");
            }
        }
        public void WithdrawMoney(double sum, int id) 
        {
            Account account = accounts[id];
            if (account == null)
            {
                Console.WriteLine("Can't find account!");
            }
            else
            {
                account.Balance -= sum;
                Console.Clear();
                Console.WriteLine($"The balance was reduced! \n{account.ToString()}\nTime: {DateTime.Now}");
            }
        }
        public void DeleteAccount(int id) // TODO: to finish delete functionality
        {
            Account[] tempAccounts = new Account[accounts.Length - 1];
            for (int i = 0, j = 0; i < accounts.Length; i++)
            {
                if (i != id - 1)
                {
                    tempAccounts[j++] = accounts[i];
                }
            }
            accounts = tempAccounts;
            Console.WriteLine("Account was deleted!");
        }
        public void FindAccount(int id)
        {
            bool check = true;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                {
                    check = false;
                    Console.WriteLine(accounts[id].ToString());
                }
                else 
                {
                    continue;
                }
            }
            if (check) 
            {
                Console.WriteLine("Account wasn't found!");
            }
        }
    }
}