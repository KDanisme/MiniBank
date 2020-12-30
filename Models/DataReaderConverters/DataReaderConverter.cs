using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    class DataReaderConverter : IDataReaderConverter
    {
        public IDataReaderUserConverter UserConverter { get; set; }
        public IDataReaderAccountConverter AccountConverter { get; set; }
        public DataReaderConverter(IDataReaderUserConverter userConverter, IDataReaderAccountConverter accountConverter)
        {
            this.UserConverter = userConverter;
            this.AccountConverter = accountConverter;
        }
    }
}
