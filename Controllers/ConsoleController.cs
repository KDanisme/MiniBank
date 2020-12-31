using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MiniBank.Models;
using MiniBank.View;

namespace MiniBank.Controllers
{
    class ConsoleController : IDisposable
    {
        IConsoleView view;
        public ISqlRunner SqlRunner { get; set; }
        public ConsoleController(ISqlRunner sqlQueryRunner, IConsoleView view)
        {
            this.SqlRunner = sqlQueryRunner;
            this.view = view;

        }
        public void Start()
        {
            SqlRunner.Connection.Open();
            SelectActionUI();
        }
        public void CloseApplication() => Environment.Exit(0);
        public void SelectActionUI()
        {
            StartActionList(
                  ("List all users", SelectFromAllUsersUI),
                  ("Create new user", CreateNewUserUI));
        }
        public void SelectFromAllUsersUI()
        {
            StartModelList(SelectUserOptionsUI, SqlRunner.GetAllUsers());
        }
        public void CreateNewUserUI()
        {
            view.AskForNewUserName();
            SqlRunner.CreateNewUser(Console.ReadLine());
        }
        public void SelectUserOptionsUI(IUser user)
        {
            StartActionList(
                   ("View Accounts", () => UserAccountViewUI(user)),
                  ("Add Account", () => UserAccountCreationUI(user)),
                  ("Delete", () => SqlRunner.DeleteUserAndAccounts(user)));
        }
        public void UserAccountViewUI(IUser user)
        {
            StartModelList(AccountOptionSelectionUI, SqlRunner.GetAllAccountsForUser(user));
        }
        public void AccountOptionSelectionUI(IAccount account)
        {
            StartActionList(
                  ("Deposite", () => DepositeToAccountUI(account)),
                  ("Withdraw", () => WithdrawFromAccountUI(account)),
                  ("Delete", () => SqlRunner.DeleteAccount(account)));
        }
        public void UserAccountCreationUI(IUser user)
        {
            view.AskForNewAccountType();
            if (Enum.TryParse(Console.ReadLine(), out AccountType type))
                SqlRunner.CreateNewAccountForUser(user, type);
            else
            {
                view.DisplayInvalidTypeMessage();
                Console.ReadKey();
            }
        }
        public void DepositeToAccountUI(IAccount account)
        {
            view.AskForDepositeAmmount();
            if (decimal.TryParse(Console.ReadLine(), out decimal ammount))
                SqlRunner.DepositeToAccount(account, ammount);
            else
                view.DisplayInvalidMoneyFormat();
        }
        public void WithdrawFromAccountUI(IAccount account)
        {
            view.AskForWithdrawAmmount();
            if (decimal.TryParse(Console.ReadLine(), out decimal ammount))
                WithdrawFromAccount(account, ammount);
            else
                view.DisplayInvalidMoneyFormat();
        }
        void WithdrawFromAccount(IAccount account, decimal ammount)
        {
            try
            {
                SqlRunner.WithdrawFromAccount(account, ammount);
            }
            catch (Exception)
            {
                view.DisplayWithdrawError();
                Console.ReadKey();
            }
        }

        void StartModelList<T>(Action<T> action, IEnumerable<T> models) where T : IModel
        {
            if (!(models is null))
                while (true)
                    if (ChooseFromModelList((IEnumerable<IModel>)models) is T model)
                        action(model);
                    else
                        break;
        }
        void StartActionList(params (string, Action)[] actions)
        {
            if (!(actions is null))
                while (true)
                    if (ChooseFromActionList(actions) is Action action)
                        action();
                    else
                        break;
        }
        public Action ChooseFromActionList((string text, Action action)[] list)
        {
            if (list is null)
            {
                view.DisplayEmptyList();
                Console.ReadKey();
                return null;
            }
            int index = 0;
            while (true)
            {
                view.PrintInteractiveActionList(list, index);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        return list[index].action;
                    case ConsoleKey.UpArrow:
                        index = index == 0 ? list.Length - 1 : index - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        index = index == list.Length - 1 ? 0 : index + 1;
                        break;
                    case ConsoleKey.Backspace:
                        return null;
                    default:
                        break;
                }
            }
        }
        public IModel ChooseFromModelList(IEnumerable<IModel> models)
        {
            if (models is null || !models.Any())
            {
                view.DisplayEmptyList();
                Console.ReadKey();
                return null;
            }
            IModel[] modelsArr = models.ToArray();
            int index = 0;
            while (true)
            {
                view.PrintInteractiveModelList(modelsArr, index);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        return modelsArr[index];
                    case ConsoleKey.UpArrow:
                        index = index == 0 ? modelsArr.Length - 1 : index - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        index = index == modelsArr.Length - 1 ? 0 : index + 1;
                        break;
                    case ConsoleKey.Backspace:
                        return null;
                    default:
                        break;
                }
            }
        }

        public void Dispose()
        {
            SqlRunner.Connection.Dispose();
        }
    }
}
