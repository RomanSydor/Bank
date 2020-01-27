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
        public Account[] accounts = new Account[1];
        //public Account FindAccount(int id)
        //{
        //    for (int i = 0; i < accounts.Length; i++)
        //    {
        //        if (accounts[i].Id == id)
        //            return accounts[i];
        //    }
        //    return null;
        //}
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
            Customer customer = new Customer(firstName, lastName, birthDate);
            Account account = new Account(startBalance, (customer.FirstName + " " + customer.LastName));
            if (account == null)
            {
                Console.WriteLine("\nError of creation account!");
            }
            else 
            {
                Account[] tempAccounts = new Account[accounts.Length + 1];
                for (int i = 0; i < accounts.Length; i++) 
                {
                    tempAccounts[i] = accounts[i];
                    tempAccounts[tempAccounts.Length - 1] = account;
                    accounts = tempAccounts;
                }
            }
            Console.WriteLine($"\nAccount was created!\n{customer.ToString()}\n\n{account.ToString()}");
        }
        public void TopUpAccount(double sum, int id) 
        {
            Account account = accounts[id];// TODO check id input
            if (account == null) 
            {
                Console.WriteLine("Can't find account!");
            }
            else 
            {
                account.IncreaseBalance(sum);
                Console.WriteLine($"The balance was increased! {account.ToString()}\nTime: {DateTime.Now}");
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
                account.ReduceBalance(sum);
                Console.WriteLine($"The balance was reduced! {account.ToString()}\nTime: {DateTime.Now}");
            }
        }
        public void DeleteAccount(int id) 
        {
            Account[] tempAccounts = new Account[accounts.Length - 1];
            for (int i = 0, j = 0; i < accounts.Length; i++)
            {
                if (i != id)
                    tempAccounts[j++] = accounts[i];
            }
            accounts = tempAccounts;
            Console.WriteLine("Account was deleted!");
        }
    }
}
