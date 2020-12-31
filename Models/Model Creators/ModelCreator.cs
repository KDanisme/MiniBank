using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    class ModelCreator : IModelCreator
    {
        public IUserCreator UserCreator { get; set; }
        public IAccountCreator AccountCreator { get; set; }


        public ModelCreator(IUserCreator userCreator, IAccountCreator accountCreator)
        {
                this.UserCreator = userCreator;
                this.AccountCreator = accountCreator;
        }
    }
}
