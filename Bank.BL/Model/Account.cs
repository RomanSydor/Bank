using System;

namespace Bank.BL.Model
{
    /// <summary>
    /// Model of bank account
    /// </summary>
    [Serializable]
    public class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public string Owner { get; }
        public DateTime Created { get; }
        public string Password { get; }

        public Account[] accounts = BankEvents.accounts;
        public override string ToString()
        {
            return $"Account: {Id}\nOwner: {Owner}\nMoney: ${Balance}\nCreated: {Created.ToShortDateString()}";
        }

        public Account(double balance, string owner, string password)
        {
            Id = accounts.Length;
            Balance = balance;
            Owner = owner;
            Password = password;
            Created = DateTime.Now;
        }

        public Account()
        {

        }
    }
}
