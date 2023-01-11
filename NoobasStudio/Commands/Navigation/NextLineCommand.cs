using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NoobasStudio.Commands
{
    public class NextLineCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        //TranslatedText translatedText;
        public NextLineCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            //translatedText = new TranslatedText();
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.CurrentSelectedItem)
                || e.PropertyName == nameof(_globalViewModel.Subs)
                || e.PropertyName == nameof(_globalViewModel.CountOfSubs)
                || e.PropertyName == nameof(_globalViewModel.Translation))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.Subs != null 
                && _globalViewModel.CurrentSelectedItem < _globalViewModel.CountOfSubs
                && _globalViewModel.Translation.Trim() != String.Empty) && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            _globalViewModel.CurrentSelectedItem++;
            _globalViewModel.Translation = String.Empty;
        }
    }
}
