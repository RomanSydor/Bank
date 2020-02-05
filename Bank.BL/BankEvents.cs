using Bank.BL.Model;
using System;

namespace Bank.BL
{
    [Serializable]
    public class BankEvents
    {
        public static Account Account = new Account();
        public static Account[] accounts;
        public static AccountController controller = new AccountController();


        public Account[] OpenAccount()
        {
            accounts = controller.Load();
            Console.Write("Input your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Input your last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Input date of your birth(mm.dd.yyyy): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Input password: ");
            string password = Console.ReadLine();
            Console.Write("Start replenishment: $");
            double startBalance = double.Parse(Console.ReadLine());
            Console.Clear();
            Customer customer = new Customer(firstName, lastName, birthDate);
            Account = new Account(startBalance, (customer.FirstName + " " + customer.LastName), password);
            if (Account == null)
            {
                Console.WriteLine("\nError of creation account!");
            }
            else
            {
                if (accounts.Length == 0)
                {
                    accounts = new Account[] { Account };
                }
                else
                {
                    Account[] tempAccounts = new Account[accounts.Length + 1];
                    for (int i = 0; i < accounts.Length; i++)
                    {
                        tempAccounts[i] = accounts[i];
                        tempAccounts[tempAccounts.Length - 1] = Account;
                    }
                    accounts = tempAccounts;

                }
            }
            Console.WriteLine($"Account was created!\n{customer.ToString()}\n\n{Account.ToString()}");
            controller.Save(accounts);
            return accounts;
        }
        public Account TopUpAccount(double sum, int id)
        {
            // accounts = controller.Load();
            //for (int i = 0; i < accounts.Length; i++) 
            //{
            //    if (accounts[i].Password == password)
            //    {
            //        Account = accounts[i];
            //    }
            //}
            Account = accounts[id];
            if (Account == null)
            {
                Console.WriteLine("Can't find account!");
            }
            else
            {
                Account.Balance += sum;
                Console.Clear();
                Console.WriteLine($"The balance was increased! \n{Account.ToString()}\nTime: {DateTime.Now}");
            }
            controller.Save(accounts);
            return Account;
        }
        public Account WithdrawMoney(double sum, int id)
        {
            //accounts = controller.Load();
            Account = accounts[id];
            if (Account == null)
            {
                Console.WriteLine("Can't find account!");
            }
            else
            {
                Account.Balance -= sum;
                Console.Clear();
                Console.WriteLine($"The balance was reduced! \n{Account.ToString()}\nTime: {DateTime.Now}");
            }
            controller.Save(accounts);
            return Account;
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
        public Account FindAccount(int id, string password)
        {
            accounts = controller.Load();
            bool check = true;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id && accounts[i].Password == password)
                {
                    check = false;
                    Console.WriteLine(accounts[id].ToString());
                    Account = accounts[id];
                }
                else
                {
                    continue;
                }
            }
            if (check)
            {
                Console.WriteLine("Invalid id or password!");
            }
            //controller.Save(accounts);
            return Account;
        }

        public Account[] EndSession()
        {
            controller.Save(accounts);
            return accounts;
        }
    }
}