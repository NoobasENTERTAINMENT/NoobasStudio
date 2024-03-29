﻿using NoobasStudio.Core;
using NoobasStudio.ViewModels;
using System;
using System.ComponentModel;

namespace NoobasStudio.Commands
{
    public class NextLineCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        private ProjectData _projectData = new ProjectData();
        public NextLineCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
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
                && _globalViewModel.CurrentSelectedIndex < _globalViewModel.CountOfSubs
                && _globalViewModel.Translation.Trim() != String.Empty
                && _globalViewModel.Translation != null) && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            if(_globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex + 1] == null)
            {
                _globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex + 1] = String.Empty;
            }
            if (_globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex] != null)
            {
                _globalViewModel.CurrentSelectedIndex++;
                _globalViewModel.Translation = _globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedIndex];
            }
            _projectData.IsHaveUnsavedChanges(_globalViewModel);
        }
    }
}
