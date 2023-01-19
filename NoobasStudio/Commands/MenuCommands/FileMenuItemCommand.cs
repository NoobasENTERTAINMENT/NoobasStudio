using NoobasStudio.ViewModels;
using System.ComponentModel;

namespace NoobasStudio.Commands.MenuCommands
{
    public class FileMenuItemCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        public FileMenuItemCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.IsProjectCreated) 
                || e.PropertyName == nameof(_globalViewModel.Subs)
                || e.PropertyName == nameof(_globalViewModel.YourPart))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.IsProjectCreated != false && _globalViewModel.Subs != null && _globalViewModel.YourPart != null) && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
        }
    }
}
