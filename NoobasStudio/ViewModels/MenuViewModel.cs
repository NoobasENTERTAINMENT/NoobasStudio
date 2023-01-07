using NoobasStudio.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoobasStudio.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ICommand LoadSaveCommand { get; }
        public ICommand LoadFileCommand { get; }
        public MenuViewModel()
        {
            LoadSaveCommand = new LoadSaveCommand();
            LoadFileCommand = new LoadFileCommand();
        }
    }
}
