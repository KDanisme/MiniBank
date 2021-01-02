using MiniBank.Models;
using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank
{
    class SqlRunner : ISqlRunner
    {

        public IDataReaderConverter DataReaderConverter { get; set; }
        public IDbConnection Connection { get; set; }
        public SqlRunner(IDbConnection connection, IDataReaderConverter dataReaderConverter)
        {
            this.Connection = connection;
            this.DataReaderConverter = dataReaderConverter;
        }
        public void DeleteUserAndAccounts(IUser user)
        {
            DeleteUsersAccounts(user);
            DeleteUser(user);
        }
        public void DepositeToAccount(IAccount account, decimal ammount)
        {
            account.Deposite(ammount);
            UpdateAccount(account);
        }
        public void WithdrawFromAccount(IAccount account, decimal ammount)
        {
            account.Withdraw(ammount);
            UpdateAccount(account);
        }
        public void DeleteUsersAccounts(IUser user) =>
            ExecuteCommand($"DELETE FROM [Account] WHERE UserId = {user.Id}");
        void DeleteUser(IUser user) =>
            ExecuteCommand($"DELETE FROM [User] WHERE Id = {user.Id}");
        public void DeleteAccount(IAccount account) =>
            ExecuteCommand($"DELETE FROM [Account] WHERE Id = {account.Id}");
        public void CreateNewAccountForUser(IUser user, AccountType type) =>
            ExecuteCommand($"INSERT INTO [Account] (UserId,Balance,Type) VALUES({user.Id},{Account.StartingBalance},{(int)type})");
        public void CreateNewUser(string name) =>
            ExecuteCommand($"INSERT INTO [User] (Name) VALUES('{name}')");
        public void UpdateAccount(IAccount account) =>
            ExecuteCommand($"UPDATE [Account] SET Balance = {account.Balance} WHERE Id = {account.Id}");
        void ExecuteCommand(string query)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<IUser> GetAllUsers()
        {
            using (IDataReader datareader = GetQueryResult("SELECT * FROM [User]"))
                while (datareader.Read())
                    yield return DataReaderConverter.UserConverter.Convert(datareader);
        }
        public IEnumerable<IAccount> GetAllAccountsForUser(IUser user)
        {
            using (IDataReader datareader = GetQueryResult($"SELECT * FROM [Account] WHERE (UserId) = {user.Id}"))
                while (datareader.Read())
                    yield return DataReaderConverter.AccountConverter.Convert(datareader);
        }
        IDataReader GetQueryResult(string query)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = query;
                return command.ExecuteReader();
            }
        }
    }
}
