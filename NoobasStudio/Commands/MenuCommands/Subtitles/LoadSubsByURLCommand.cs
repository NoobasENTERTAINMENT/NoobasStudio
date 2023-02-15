using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.MenuCommands.Subtitles
{
    public class LoadSubsByURLCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;

        public LoadSubsByURLCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }

        public override void Execute(object parameter)
        {
            string URL = parameter as string;
        }
    }
}
