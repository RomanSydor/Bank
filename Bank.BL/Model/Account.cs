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
            return $"Account: {Id}\nOwner: {Owner}\nMoney: {Balance}\nCreated: {Created}";
        }
        public double IncreaseBalance(double sum)
        {
            return Balance - sum;
        }
        public double ReduceBalance(double sum) 
        {
            return Balance + sum;
        }
        public Account(int id, double balance, string owner) 
        {
            Id = id;
            Balance = balance;
            Owner = owner;
            Created = DateTime.Now;
        }
    }
}
