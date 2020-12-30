using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models.Accounts
{
    class DataReaderUserConverter : IDataReaderUserConverter
    {
        public IUserCreator UserCreator { get; set; }

        public DataReaderUserConverter(IUserCreator userCreator)
        {
            UserCreator = userCreator;
        }

        public IUser Convert(IDataReader dataReader)
        {
            return UserCreator.Create((int)dataReader["Id"], (string)dataReader["Name"]);
        }
    }
}
