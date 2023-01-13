﻿using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands
{
    public class PreviousLineCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.CurrentSelectedItem != 0 && _globalViewModel.Subs != null && _globalViewModel.YourPart != null) && base.CanExecute(parameter);
        }
        public PreviousLineCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_globalViewModel.CurrentSelectedItem) 
                || e.PropertyName == nameof(_globalViewModel.Subs)
                || e.PropertyName == nameof(_globalViewModel.YourPart))
            {
                OnCanExecuteChanged();
            }
        }
        public override void Execute(object parameter)
        {
            _globalViewModel.Translation = String.Empty;
            _globalViewModel.CurrentSelectedItem--;
            _globalViewModel.Translation = _globalViewModel.TranslatedText[_globalViewModel.CurrentSelectedItem];
        }
    }
}
