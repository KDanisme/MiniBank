using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models.Accounts
{
    enum AccountType
    {
        Simple,
        Vip
    }
    interface IAccount : IModel
    {
        int Id { get; set; }
        int UserId { get; set; }
        decimal Balance { get; set; }
        AccountType Type { get; set; }
        
        void Deposite(decimal ammount);
        void Withdraw(decimal ammount);

    }
}
