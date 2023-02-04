using NoobasStudio.Core;
using NoobasStudio.ViewModels;
using System;
using System.ComponentModel;
using System.Timers;

namespace NoobasStudio.Commands.Navigation
{
    public class AddTranslatedLineCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        private ProjectData _projectData = new ProjectData();
        private static System.Timers.Timer timer;
        public AddTranslatedLineCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            SetTimer();
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void SetTimer()
        {
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += AtimerEllapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void AtimerEllapsed(object sender, ElapsedEventArgs e)
        {
            _globalViewModel.SnackbarIsActive = false;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.CurrentSelectedIndex)
                || e.PropertyName == nameof(_globalViewModel.Subs)
                || e.PropertyName == nameof(_globalViewModel.YourPart)
                || e.PropertyName == nameof(_globalViewModel.CountOfSubs)
                || e.PropertyName == nameof(_globalViewModel.Translation)
                || e.PropertyName == nameof(_globalViewModel.IsTranslationEnded))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.Subs != null
                && _globalViewModel.YourPart != null
                && _globalViewModel.CurrentSelectedIndex <= _globalViewModel.CountOfSubs
                && _globalViewModel.Translation.Trim() != String.Empty
                && _globalViewModel.Translation != null) && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            if (_globalViewModel.CountOfSubs == _globalViewModel.CurrentSelectedIndex)
            {
                _globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex] = _globalViewModel.Translation;
                _globalViewModel.Translation = string.Empty;
                _globalViewModel.IsTranslationEnded = true;
                _globalViewModel.SnackbarIsActive = true;          
            }
            else
            {
                _globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex] = _globalViewModel.Translation;

                if (_globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex + 1] != null)
                {
                    _globalViewModel.Translation = _globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex + 1];
                }
                else
                {
                    _globalViewModel.Translation = string.Empty;
                }
                
                _globalViewModel.CurrentSelectedIndex++;
            }
            _projectData.IsHaveUnsavedChanges(_globalViewModel);
        }
    }
}
