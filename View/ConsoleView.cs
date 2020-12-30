using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MiniBank.Controllers;
using MiniBank.Models.Users;
using MiniBank.Models.Accounts;
using MiniBank.Models;

namespace MiniBank.Views
{
    class ConsoleView : IConsoleView
    {
        public IConsoleController Controller { get; set; }

        public void Update()
        {
            Console.Clear();
            
            for (int i = 0; i < Controller.currentListHandler.ItemList.Count; i++)
                if (IsSelectedIndex(i))
                {
                    StartHighlighting();
                    PrintModel(Controller.currentListHandler[i].model);
                    StopHighlighting();
                }
                else
                    PrintModel(Controller.currentListHandler[i].model);
        }

        bool IsSelectedIndex(int i)
        {
            return i == Controller.currentListHandler.SelectedIndex;
        }
        void StartHighlighting()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        void StopHighlighting()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        void PrintModel(IModel model)
        {
            if (model is IUser user)
                PrintUser(user);
            else if (model is IAccount account)
                PrintAccount(account);
            else if (model is ITextItem textItem)
                PrintTextItem(textItem);
        }
        void PrintUser(IUser user)
        {
            Console.WriteLine(
                           $"Id: {user.Id}\t" +
                           $"Name: {user.Name}");
        }
        void PrintAccount(IAccount account)
        {
            Console.WriteLine(
                        $"Id: {account.Id}\t" +
                        $"Type: {Enum.GetName(typeof(AccountType), account.Type)}\t" +
                        $"Balance: {account.Balance}");
        }
        void PrintTextItem(ITextItem textItem)
        {
            Console.WriteLine(textItem.Text);
        }
    }
}
