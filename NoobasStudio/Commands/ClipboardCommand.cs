using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NoobasStudio.Commands
{
    public class ClipboardCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        public ClipboardCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }

        public override void Execute(object parameter)
        {
            Clipboard.SetText(_globalViewModel.Result);
        }
    }
}
