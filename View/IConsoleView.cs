using MiniBank.Controllers;
using MiniBank.Models;
using System;
using System.Collections.Generic;

namespace MiniBank.View
{
    interface IConsoleView
    {
        IModelPrinter ModelPrinter { get; set; }
        void AskForNewUserName();
        void AskForNewAccountType();
        void AskForDepositeAmmount();
        void AskForWithdrawAmmount();
        void DisplayWithdrawError();
        void DisplayInvalidTypeMessage();
        void DisplayInvalidMoneyFormat();
        void PrintInteractiveActionList((string text, Action action)[] list, int index);
        void PrintInteractiveModelList(IModel[] models, int index);
        void DisplayEmptyList();
    }
}