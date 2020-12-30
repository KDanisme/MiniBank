using MiniBank.Controllers;

namespace MiniBank.Views
{
    interface IConsoleView : IView
    {
        IConsoleController Controller { get; set; }
        void Update();
    }
}