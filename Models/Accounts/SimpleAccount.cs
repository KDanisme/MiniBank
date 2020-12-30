using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models.Accounts
{
    class SimpleAccount : Account
    {
        public SimpleAccount(int id,int userId, double balance) 
            : base(id,AccountType.Simple, userId, balance) { }
        public SimpleAccount(int userId, double balance)
            : base(AccountType.Simple, userId, balance) { }
        public override void Deposite(double ammount)
        {
            Balance += ammount;
        }
        public override void Withdraw(double ammount)
        {
            if (Balance - ammount < 0)
                throw new Exception("Not enough money in account");
            Balance -= ammount;
        }

    }
}
