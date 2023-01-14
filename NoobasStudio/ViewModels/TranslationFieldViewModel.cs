using Microsoft.VisualStudio.PlatformUI;
using NoobasStudio.Commands;
using NoobasStudio.Commands.MenuCommands;
using NoobasStudio.Commands.Navigation;
using NoobasStudio.Models;
using NoobasStudio.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NoobasStudio.ViewModels
{
    public class TranslationFieldViewModel : ViewModelBase
    {
        public readonly GlobalViewModel _globalViewModel;
        public TranslationFieldViewModel(NavigationStore navigationStore, GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            AddTranslatedLineCommand = new AddTranslatedLineCommand(_globalViewModel);
            OpenTranslatorCommand = new OpenTranslatorCommand(navigationStore, _globalViewModel);
        }

        public ICommand AddTranslatedLineCommand { get; }
        public ICommand OpenTranslatorCommand { get; }

        private string _translation = String.Empty;
        public string Translation
        {
            get
            {
                return _translation;
            }
            set
            {
                _translation = value;
                OnPropertyChanged();
            }
        }

        private bool _isTranslationEnded = true;
        public bool IsTranslationEnded
        {
            get
            {
                return _isTranslationEnded;
            }
            set
            {
                _isTranslationEnded = value;
                OnPropertyChanged();
            }
        }
    }
}
