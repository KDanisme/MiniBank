using MiniBank.Models.Accounts;
using MiniBank.Models.Users;
using System;

namespace MiniBank.Models
{
    class TextItemCreator : ITextItemCreator
    {
        public ITextItem Create(string text)
        {
            return new TextItem(text);
        }
    }
}