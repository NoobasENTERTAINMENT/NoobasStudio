using NoobasStudio.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoobasStudio.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public ICommand CloseCommand { get; }
        public ViewModelBase CurrentViewModel { get; }
        public MainWindowViewModel()
        {
            CurrentViewModel = new GlobalViewModel();
            CloseCommand = new CloseCommand();
        }
    }
}
