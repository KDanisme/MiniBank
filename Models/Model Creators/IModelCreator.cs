﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Models
{
    interface IModelCreator : IDbModelCreator
    {

        ITextItemCreator TextItemCreator { get; set; }
        
        IListHandlerCreator ListHandlerCreator { get; set; }
    }
}