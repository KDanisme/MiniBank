using MiniBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    class ListHandlerCreator : IListHandlerCreator
    {

        public ListHandler Create(List<(IModel model, Action action)> itemList)
        {
            return new ListHandler(itemList);
        }
    }
}
