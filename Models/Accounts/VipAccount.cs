using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models.Accounts
{
    class VipAccount : Account
    {
        public VipAccount(int id, int userId, decimal balance)
            : base(id, AccountType.Vip, userId, balance) { }
        public override void Deposite(decimal ammount) =>
            Balance += ammount;
        public override void Withdraw(decimal ammount) =>
            Balance -= ammount;
    }
}
