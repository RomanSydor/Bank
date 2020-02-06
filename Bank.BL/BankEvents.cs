using Bank.BL.Model;
using System;

namespace Bank.BL
{
    /// <summary>
    /// Realised working bank accounts
    /// </summary>
    [Serializable]
    public class BankEvents
    {
        public static Account Account = new Account();
        public static Account[] accounts;
        public static AccountController controller = new AccountController();

        /// <summary>
        /// Realised create account logic 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Realised increase of bank account
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account InputMoney(double sum, int id)
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

        /// <summary>
        /// Realised reduce of bank account
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account OutputMoney(double sum, int id)
        {
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

        /// <summary>
        /// Realised closing of bank account 
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Realised finding account and showing its info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Account FindAccount(int id, string password)
        {
            accounts = controller.Load();
            bool check = true;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id && accounts[i].Password == password)
                {
                    Console.Clear();
                    check = false;
                    Console.WriteLine(accounts[id].ToString());
                    Account = accounts[id];
                    break;
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
            return Account;
        }

        /// <summary>
        /// Realised app closing
        /// </summary>
        /// <returns></returns>
        public Account[] EndSession()
        {
            controller.Save(accounts);
            return accounts;
        }
    }
}