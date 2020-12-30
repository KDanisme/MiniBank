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
        double Balance { get; set; }
        AccountType Type { get; set; }
        
        void Deposite(double ammount);
        void Withdraw(double ammount);

    }
}
