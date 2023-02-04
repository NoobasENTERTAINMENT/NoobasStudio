﻿using NoobasStudio.Core;
using NoobasStudio.ViewModels;
using System.ComponentModel;

namespace NoobasStudio.Commands
{
    public class SaveProjectCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        private ProjectData _projectData;
        public SaveProjectCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _projectData = new ProjectData();
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
            _projectData.SaveJSON(_globalViewModel);
            _projectData.IsHaveUnsavedChanges(_globalViewModel);
        }
    }
}
