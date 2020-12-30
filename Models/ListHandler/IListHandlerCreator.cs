using MiniBank.Models;
using System;
using System.Collections.Generic;

namespace MiniBank.Models
{
    interface IListHandlerCreator
    {
        ListHandler Create(List<(IModel model, Action action)> itemList);
    }
}