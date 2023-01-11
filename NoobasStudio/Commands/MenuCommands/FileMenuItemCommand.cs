using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.MenuCommands
{
    public class FileMenuItemCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        public FileMenuItemCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.IsProjectCreated) 
                || e.PropertyName == nameof(_globalViewModel.Subs))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.IsProjectCreated != false && _globalViewModel.Subs != null) && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
        }
    }
}
