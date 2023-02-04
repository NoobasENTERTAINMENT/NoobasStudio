using NoobasStudio.Core;
using NoobasStudio.ViewModels;
using System;
using System.ComponentModel;

namespace NoobasStudio.Commands
{
    public class PreviousLineCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        private ProjectData _projectData = new ProjectData();
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.CurrentSelectedIndex != 0 && _globalViewModel.Subs != null && _globalViewModel.YourPart != null) && base.CanExecute(parameter);
        }
        public PreviousLineCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_globalViewModel.CurrentSelectedIndex) 
                || e.PropertyName == nameof(_globalViewModel.Subs)
                || e.PropertyName == nameof(_globalViewModel.YourPart))
            {
                OnCanExecuteChanged();
            }
        }
        public override void Execute(object parameter)
        {
            _globalViewModel.IsTranslationEnded = false;
            _globalViewModel.Translation = String.Empty;
            _globalViewModel.CurrentSelectedIndex--;
            _globalViewModel.Translation = _globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex];
            _projectData.IsHaveUnsavedChanges(_globalViewModel);
        }
    }
}
