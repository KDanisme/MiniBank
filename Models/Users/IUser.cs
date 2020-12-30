using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBank.Models.Accounts;
namespace MiniBank.Models.Users
{
    interface IUser : IModel
    {
        List<IAccount> Accounts { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}
