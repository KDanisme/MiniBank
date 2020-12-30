using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models.Accounts
{
    class DataReaderAccountConverter : IDataReaderAccountConverter
    {
        public IAccountCreator AccountCreator { get; set; }
        public DataReaderAccountConverter(IAccountCreator accountCreator)
        {
            this.AccountCreator = accountCreator;
        }
        public IAccount Convert(IDataReader dataReader)
        {
            return AccountCreator.Create((int)dataReader["Id"], (AccountType)dataReader["Type"], (int)dataReader["userId"], (double)dataReader["Balance"]);
        }
    }
}
