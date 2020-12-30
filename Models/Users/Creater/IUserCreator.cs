using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    interface IUserCreator
    {
        IUser Create(string name);
        IUser Create(int id,string name);
    }
}
