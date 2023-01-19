using NoobasStudio.ViewModels;
using System.ComponentModel;

namespace NoobasStudio.Commands
{
    public class SubtitlesMenuItemCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        public SubtitlesMenuItemCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.IsProjectCreated))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.IsProjectCreated != false) && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
        }
    }
}
