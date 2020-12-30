using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    interface ITextItemCreator
    {
        ITextItem Create(string text);
    }
}
