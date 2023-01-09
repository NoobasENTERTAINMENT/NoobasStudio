using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands
{
    public class AddTranslateLineCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        TranslatedText translatedText = new TranslatedText();
        public AddTranslateLineCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.Translation) 
                || e.PropertyName == nameof(_globalViewModel.CurrentSelectedItem)
                || e.PropertyName == nameof(_globalViewModel.Subs)
                || e.PropertyName == nameof(_globalViewModel.CountOfSubs)
                || e.PropertyName == nameof(_globalViewModel.IsTranslationEnded))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.Translation.Trim() != String.Empty
                && _globalViewModel.Translation != null
                && _globalViewModel.Subs != null
                && _globalViewModel.CurrentSelectedItem <= _globalViewModel.CountOfSubs) 
                && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            translatedText.AddLine(_globalViewModel.Translation);
            _globalViewModel.Translation = string.Empty;
            _globalViewModel.CurrentSelectedItem++;

        }
    }
}
