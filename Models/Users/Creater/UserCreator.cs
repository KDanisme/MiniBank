using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    class UserCreator : IUserCreator
    {
        public IUser Create(string name)
        {
            return new User(name);
        }
        public IUser Create(int id, string name)
        {
            return new User(id, name);
        }
    }
}
