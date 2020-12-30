using MiniBank.Models;
using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System.Collections.Generic;

namespace MiniBank.Controllers
{
    enum ControllerState
    {
        Main,
        UserCreation,
        AccountCreation,
        Withdraw_Deposit,
        ListAllUsers,
        Deposite,
        Withdraw,
    }
    interface IConsoleController : IController
    {

        IDataReaderConverter DataReaderConverter { get; set; }
        IModelCreator ModelCreator { get; set; }
        IListHandler currentListHandler { get; set; }
        ControllerState State { get; set; }
        void CreateNewAccountForUser(IUser user, IAccount account);
        void CreateNewUser(IUser user);
        void DeleteUserAndAccounts(IUser user);
        IEnumerable<IAccount> ListAllAccountsForUser();
        IEnumerable<IUser> ListAllUsers();
        void MainLoop();
        void WaitForInput();
    }
}