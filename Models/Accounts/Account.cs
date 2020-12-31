using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models.Accounts
{
    abstract class Account : IAccount
    {
        public static decimal StartingBalance = 0;
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public Account(int id, AccountType type, int userId, decimal balance) 
        {
            this.Id = id;
            this.UserId = userId;
            this.Balance = balance;
            this.Type = type;
        }
        public abstract void Deposite(decimal ammount);
        public abstract void Withdraw(decimal ammount);
    }
}
