using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BL.Model
{
    [Serializable]
    public class Account
    {
        public int Id { get; }
        public double Balance { get; set; }
        public string Owner { get; }
        public DateTime Created { get; }
        public string Password { get; }
        public override string ToString()
        {
            return $"Account: {Id}\nOwner: {Owner}\nMoney: ${Balance}\nCreated: {Created.ToShortDateString()}";
        }

        static int counter = 0;
        public Account(double balance, string owner, string password) 
        {
            Id = counter++;
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
