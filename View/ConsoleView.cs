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

namespace MiniBank.View
{
    class ConsoleView : IConsoleView
    {

        public IModelPrinter ModelPrinter { get; set; }
        public ConsoleView(IModelPrinter modelPrinter)
        {
            this.ModelPrinter = modelPrinter;
        }

        public void PrintInteractiveModelList(IModel[] models, int index)
        {
            Console.Clear();
            for (int i = 0; i < models.Length; i++)
                if (i == index)
                {
                    StartHighlighting();
                    ModelPrinter.PrintModel(models[i]);
                    StopHighlighting();
                }
                else
                    ModelPrinter.PrintModel(models[i]);
        }
        public void PrintInteractiveActionList((string text, Action action)[] actions, int index) {
            Console.Clear();
            for (int i = 0; i < actions.Length; i++)
                if (i == index)
                {
                    StartHighlighting();
                    Console.WriteLine(actions[i].text);
                    StopHighlighting();
                }
                else
                    Console.WriteLine(actions[i].text);
        }
        void StartHighlighting() => Console.ForegroundColor = ConsoleColor.Red;
        void StopHighlighting() => Console.ForegroundColor = ConsoleColor.Gray;
        public void AskForNewUserName()
        {
            Console.Clear();
            Console.Write("Name for new user: ");
        }
        public void AskForDepositeAmmount()
        {
            Console.Clear();
            Console.Write("Insert deposite ammount: ");
        }
        public void AskForWithdrawAmmount()
        {
            Console.Clear();
            Console.Write("Insert withdraw ammount: ");
        }
        public void AskForNewAccountType()
        {
            Console.Clear();
            Console.Write("Type of new account(Simple/Vip): ");
        }
        public void DisplayEmptyList()
        {
            Console.Clear();
            Console.WriteLine("***Empty***");
        }
        public void DisplayWithdrawError() =>
            Console.WriteLine("Cannot withdraw from account, not enough money.");
        public void DisplayInvalidTypeMessage() =>
            Console.WriteLine("Invalid type of account");
        public void DisplayInvalidMoneyFormat() =>
            Console.WriteLine("Invalid money format, must be decimal");
    }
}
