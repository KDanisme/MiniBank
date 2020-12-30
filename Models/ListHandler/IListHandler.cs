using MiniBank.Models;
using System;
using System.Collections.Generic;

namespace MiniBank.Models
{
    interface IListHandler
    {
        List<(IModel model, Action action)> ItemList { get; set; }
        int SelectedIndex { get; set; }
        void Click();
        void MoveDown();
        void MoveUp();
        (IModel model, Action action) this[int index]
        {
            get;
            set;
        }
    }

}