using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.Navigation
{
    public class WindowStateChangeCommand : CommandBase
    {
        readonly MainWindowViewModel _mainWindowViewModel;
        public WindowStateChangeCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
        public override void Execute(object parameter)
        {
            if (_mainWindowViewModel.WindowState == "Normal")
            {
                _mainWindowViewModel.WindowState = "Maximized";
                return;
            }
            if (_mainWindowViewModel.WindowState == "Maximized")
            {
                _mainWindowViewModel.WindowState = "Normal";
                return;
            }
        }
    }
}
