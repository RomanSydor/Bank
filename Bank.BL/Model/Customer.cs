using System;

namespace Bank.BL.Model
{
    /// <summary>
    /// Model of bank customer
    /// </summary>
    [Serializable]
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; }

        public Account[] accounts = BankEvents.accounts;
        public override string ToString()
        {
            return $"Customer:{FirstName} {LastName}\nId: {Id}\nDate of birth: {BirthDate.ToShortDateString()}";
        }

        public Customer(string firstName, string lastName, DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name of user can't be null!", nameof(firstName));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name of user can't be null!", nameof(lastName));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Invalid date of birth!", nameof(birthDate));
            }
            Id = accounts.Length;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        public Customer()
        {

        }
    }
}
