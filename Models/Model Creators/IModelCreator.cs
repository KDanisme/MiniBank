using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    interface IModelCreator
    {

        IUserCreator UserCreator { get; set; }
        IAccountCreator AccountCreator { get; set; }
    }
}
