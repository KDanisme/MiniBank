using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MiniBank.Views;
using MiniBank.Models;

namespace MiniBank.Controllers
{
    class ConsoleController : IConsoleController
    {
        IConsoleView view;
        IDbConnection connection;
        ControllerState state;
        public ControllerState State { get; set; }
        public IModelCreator ModelCreator { get; set; }
        public IDataReaderConverter DataReaderConverter { get; set; }
        public IListHandler currentListHandler { get; set; }
        public ConsoleController(IDbConnection connection, IConsoleView view, IModelCreator modelCreator, IDataReaderConverter dataReaderConverter)
        {
            this.ModelCreator = modelCreator;
            this.DataReaderConverter = dataReaderConverter;
            this.view = view;
            this.connection = connection;
            view.Controller = this;
            State = ControllerState.Main;
            HandleStateChange();
        
        }
        ~ConsoleController() => connection.Close();

        IDataReader GetQueryResult(string query)
        {
            var command = connection.CreateCommand();
            command.CommandText = query;
            return command.ExecuteReader();
        }
        void ExecuteCommand(string query)
        {
            var command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        public void Start()
        {
            connection.Open();
            MainLoop();
        }
        public void MainLoop()
        {
            while (true)
            {
                view.Update();
                WaitForInput();
                HandleStateChange();
            }
        }
        public void HandleStateChange() {
            switch (state)
            {

                case ControllerState.Main:
                    InitMainState();
                    break;
                case ControllerState.UserCreation:
                    break;
                case ControllerState.AccountCreation:
                    break;
                case ControllerState.Withdraw_Deposit:
                    break;
                case ControllerState.ListAllUsers:
                    break;
                case ControllerState.Deposite:
                    break;
                case ControllerState.Withdraw:
                    break;
                default:
                    break;
            }
        }
        public void  InitMainState() {
            currentListHandler = ModelCreator.ListHandlerCreator.Create(new List<(IModel, Action)>{
                (ModelCreator.TextItemCreator.Create("List all users"),()=>ListAllUsers()),
                (ModelCreator.TextItemCreator.Create("List all accounts for a given user with balance"),null),
                (ModelCreator.TextItemCreator.Create("Deposite from account"),null),
                (ModelCreator.TextItemCreator.Create("Withdraw from account"),null),
                (ModelCreator.TextItemCreator.Create("Create new user"),null),
                (ModelCreator.TextItemCreator.Create("Create new account for user"),null),
                (ModelCreator.TextItemCreator.Create("Delete user and accounts"), null)});
        }
        public void WaitForInput()
        {

            if (IsWaitingForTextInput())
                HandleTextInput();
            else
                HandleListInput();
        }
        bool IsWaitingForTextInput() {
            return currentListHandler is null;
        }
        void HandleTextInput() {

            string input = Console.ReadLine();
            switch (State)
            {
                case ControllerState.UserCreation:
                    CreateNewUser(input);
                    break;

            }
        }
        void HandleListInput()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    currentListHandler.Click();
                    break;
                case ConsoleKey.UpArrow:
                    currentListHandler.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    currentListHandler.MoveDown();
                    break;
                case ConsoleKey.Backspace:
                    GoBack();
                    break;
                default:
                    break;
            }
        }
        void GoBack()
        {
            switch (state)
            {
                case ControllerState.Main:
                    CloseApplication();
                    break;
                case ControllerState.Deposite:
                case ControllerState.Withdraw:
                case ControllerState.AccountCreation:
                case ControllerState.UserCreation:
                case ControllerState.ListAllUsers:
                    state = ControllerState.Main;
                    break;
                default:
                    break;
            }
        }
        public void CloseApplication()
        {
            Environment.Exit(0);
        }
        public void ListAllUsers()
        {
            state = ControllerState.ListAllUsers;
            currentListHandler.ItemList.Clear();
            using (IDataReader datareader = GetQueryResult("SELECT * FROM [User]"))
                while (datareader.Read())
                    currentListHandler.ItemList.Add((DataReaderConverter.UserConverter.Convert(datareader), null));


        }
        public IEnumerable<IAccount> ListAllAccountsForUser()
        {
            throw new Exception();
            IUser user = null;
            return ListAllAccountsForUser(user);
        }
        IEnumerable<IAccount> ListAllAccountsForUser(IUser user)
        {
            GetQueryResult($"SELECT * FROM [Account] WHERE (UserId) = {user.Id}");
            return null;
        }
        public void CreateNewUser(string name)
        {
            ExecuteCommand($"INSERT INTO [User] (NAME) VALUES({name})");
            state = ControllerState.Main;
        }
        public void CreateNewAccountForUser(IUser user, IAccount account)
        {
            ExecuteCommand($"INSERT INTO [Account] (UserId,Balance,Type) VALUES({user.Id},{account.Balance},{account.Type})");
        }
        public void DeleteUserAndAccounts(IUser user)
        {
            DeleteUsersAccounts(user);
            DeleteUser(user);

        }
        void DeleteUser(IUser user)
        {
            ExecuteCommand($"DELETE FROM [User] WHERE Id = {user.Id}");
        }
        void DeleteUsersAccounts(IUser user)
        {
            ExecuteCommand($"DELETE FROM [Account] WHERE UserId = {user.Id}");
        }

    }
}
