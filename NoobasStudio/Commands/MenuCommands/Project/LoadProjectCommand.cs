using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.MenuCommands.Project
{
    public class LoadProjectCommand : CommandBase
    {
        readonly private GlobalViewModel _globalViewModel;
        public LoadProjectCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
        }
    }
}
