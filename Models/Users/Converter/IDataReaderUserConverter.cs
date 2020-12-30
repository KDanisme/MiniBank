using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    interface IDataReaderUserConverter
    {
        IUserCreator UserCreator { get; set; }
        IUser Convert(IDataReader dbDataReader);

    }
}
