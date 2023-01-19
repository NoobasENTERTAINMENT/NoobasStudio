using NoobasStudio.ViewModels;

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
                _mainWindowViewModel.WindowState = "Minimized";
                return;
            }
            if (_mainWindowViewModel.WindowState == "Maximized")
            {
                _mainWindowViewModel.WindowState = "Minimized";
                return;
            }
        }
    }
}
