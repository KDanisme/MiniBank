using MiniBank.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models.Users
{
    class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User(int id, string name)
        {
            this.Id = id;
        }
    }
}
