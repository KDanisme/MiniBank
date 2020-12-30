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
        public List<IAccount> Accounts { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public User(string name)
        {
            this.Name = name;
        }
        public User(int id, string name) : this(name)
        {
            this.Id = id;
        }
    }
}
