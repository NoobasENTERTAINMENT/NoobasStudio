using NoobasStudio.Commands;
using NoobasStudio.Commands.Navigation;
using System.Windows.Input;

namespace NoobasStudio.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand WindowStateChangeCommand { get; }
        public ICommand SaveProjectCommand { get; }
        public GlobalViewModel CurrentViewModel { get; }
        public MainWindowViewModel()
        {
            CurrentViewModel = new GlobalViewModel();
            CloseCommand = new CloseCommand(CurrentViewModel);
            SaveProjectCommand = CurrentViewModel.SaveProjectCommand;
            WindowStateChangeCommand = new WindowStateChangeCommand(this);
    }

        private string _windowState = "Normal";
        public string WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                _windowState = value;
                OnPropertyChanged();
            }
        }
    }
}
