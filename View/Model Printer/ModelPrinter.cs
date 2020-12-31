using MiniBank.Models;
using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.View
{
    class ModelPrinter : IModelPrinter
    {
        public void PrintModel(IModel model)
        {
            if (model is IUser user)
                PrintUser(user);
            else if (model is IAccount account)
                PrintAccount(account);
        }
        void PrintUser(IUser user) => Console.WriteLine(
                           $"Id: {user.Id}\t" +
                           $"Name: {user.Name}");

        void PrintAccount(IAccount account) => Console.WriteLine(
                        $"Id: {account.Id}\t" +
                        $"Type: {Enum.GetName(typeof(AccountType), account.Type)}\t" +
                        $"Balance: {account.Balance}");
    }
}
