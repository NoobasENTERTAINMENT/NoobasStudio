using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.Navigation
{
    public class AddTranslatedLineCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        public AddTranslatedLineCommand(GlobalViewModel globalViewModel)
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
        }
    }
}
