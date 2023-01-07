using NoobasStudio.Commands;
using NoobasStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoobasStudio.ViewModels
{
    public class GlobalViewModel : ViewModelBase
    {
        public ICommand LoadSaveCommand { get; }
        public ICommand LoadFileCommand { get; }

        private List<string> _subs;
        public List<string> Subs
        {
            get { return _subs; }
            set { _subs = value; OnPropertyChanged(); }
        }

        public GlobalViewModel()
        {
            LoadSaveCommand = new LoadSaveCommand();
            LoadFileCommand = new LoadFileCommand();
            //Subs =
        }
    }
}
