using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BL.Model
{
    public class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public string Owner { get; set; }
        public DateTime Created { get; set; }
        public override string ToString()
        {
            return $"Account: {Id}\nOwner: {Owner}\nMoney: ${Balance}\nCreated: {Created.ToShortDateString()}";
        }
        //public double IncreaseBalance(double sum)
        //{
        //    return Balance + sum;
        //}
        //public double ReduceBalance(double sum) 
        //{
        //    return Balance - sum;
        //}
        static int counter = 0;
        public Account(double balance, string owner) 
        {
            Id = ++counter;
            Balance = balance;
            Owner = owner;
            Created = DateTime.Now;
        }

        public Account() 
        {

        }
    }
}
