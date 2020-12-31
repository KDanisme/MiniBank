using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    interface IAccountCreator
    {
        IAccount Create(int id,AccountType type, int userId, decimal balance = 0);
    }
}
