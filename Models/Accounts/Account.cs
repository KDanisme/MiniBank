using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models.Accounts
{
    abstract class Account : IAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Balance { get; set; }
        public AccountType Type { get; set; }
        public Account(AccountType type, int userId, double balance)
        {
            this.UserId = userId;
            this.Balance = balance;
            this.Type = type;
        }
        public Account(int id, AccountType type, int userId, double balance) : this(type, userId, balance)
        {
            this.Id = id;
        }

        public abstract void Deposite(double ammount);

        public abstract void Withdraw(double ammount);
    }
}
