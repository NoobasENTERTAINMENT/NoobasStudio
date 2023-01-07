﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands
{
    public class CloseCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            App.Current.Shutdown();
        }
    }
}
