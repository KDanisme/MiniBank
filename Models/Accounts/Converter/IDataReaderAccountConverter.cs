using MiniBank.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    interface IDataReaderAccountConverter
    {
        IAccountCreator AccountCreator { get; set; }
        IAccount Convert(IDataReader dbDataReader);

    }
}
