using NoobasStudio.Commands;
using NoobasStudio.Commands.Navigation;
using NoobasStudio.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NoobasStudio.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand WindowStateChangeCommand { get; }
        public ViewModelBase CurrentViewModel { get; }
        public MainWindowViewModel()
        {
            CurrentViewModel = new GlobalViewModel();
            CloseCommand = new CloseCommand();
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
