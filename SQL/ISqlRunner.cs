using MiniBank.Models;
using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System.Collections.Generic;
using System.Data;

namespace MiniBank
{
    interface ISqlRunner
    {
        IDbConnection Connection { get; set; }
        IDataReaderConverter DataReaderConverter { get; set; }

        void CreateNewAccountForUser(IUser user, AccountType type);
        void CreateNewUser(string name);
        void DeleteUserAndAccounts(IUser user);
        IEnumerable<IUser> GetAllUsers();
        void UpdateAccount(IAccount account);
        IEnumerable<IAccount> GetAllAccountsForUser(IUser user);
        void DeleteAccount(IAccount account);
        void DepositeToAccount(IAccount account, decimal ammount);
        void WithdrawFromAccount(IAccount account, decimal ammount);
    }
}