using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public string Owner { get; }
        private decimal _balance;

        public BankAccount(string accountNumber, string owner)
        {
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            _balance = 0.0m;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) 
                throw new ArgumentException("Amount must be positive");

                _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");
            if (amount > _balance) throw new InvalidOperationException("Insufficient funds");
            _balance -= amount;
        }

        public decimal GetBalance() => _balance;
    }
}
