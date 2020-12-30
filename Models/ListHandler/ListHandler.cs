using MiniBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    class ListHandler : IListHandler
    {
        public List<(IModel model, Action action)> ItemList { get; set; }
        int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value == -1)
                    selectedIndex = ItemList.Count - 1;
                else if (value == ItemList.Count)
                    selectedIndex = 0;
                else
                    selectedIndex = value;
            }
        }
        public ListHandler(List<(IModel model, Action action)> itemList)
        {
            this.ItemList = itemList;
        }
        public void Click()
        {

            ItemList[selectedIndex].action?.Invoke();
        }
        public void MoveDown()
        {
            SelectedIndex++;
        }
        public void MoveUp()
        {
            SelectedIndex--;
        }
        public (IModel model, Action action) this[int i]
        {
            get { return ItemList[i]; }
            set { ItemList[i] = value; }
        }


    }
}
