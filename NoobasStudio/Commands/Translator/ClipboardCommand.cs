using NoobasStudio.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace NoobasStudio.Commands
{
    public class ClipboardCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        public ClipboardCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.Message)
                || e.PropertyName == nameof(_globalViewModel.Result))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.Message != null && _globalViewModel.Message.Trim() != string.Empty) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            Clipboard.SetText(_globalViewModel.Result);
        }
    }
}
