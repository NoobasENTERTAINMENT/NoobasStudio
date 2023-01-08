﻿using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands
{
    public class NextLineCommand : CommandBase
    { 
        GlobalViewModel _globalViewModel;
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.Subs != null) && base.CanExecute(parameter);
        }
        public NextLineCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.CurrentSelectedItem) || e.PropertyName == nameof(_globalViewModel.Subs))
            {
                OnCanExecuteChanged();
            }
        }
        public override void Execute(object parameter)
        {
            _globalViewModel.CurrentSelectedItem++;
        }
    }
}
