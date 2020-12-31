using MiniBank.Models;
using System.Collections.Generic;

namespace MiniBank.View
{
    interface IModelPrinter
    {
        void PrintModel(IModel model);
    }
}