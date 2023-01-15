using Microsoft.VisualStudio.PlatformUI;
using NoobasStudio.Commands;
using NoobasStudio.Commands.MenuCommands;
using NoobasStudio.Commands.Navigation;
using NoobasStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NoobasStudio.ViewModels
{
    public class GlobalViewModel : ViewModelBase
    {
        public GlobalViewModel()
        {
            LoadSubsCommand = new LoadSubsCommand(this);
            NextLineCommand = new NextLineCommand(this);
            PreviousLineCommand = new PreviousLineCommand(this);
            SplitPartCommand = new SplitPartCommand(this);
            CreateProjectCommand = new CreateProjectCommand(this);
            SubtitlesMenuItemCommand = new SubtitlesMenuItemCommand(this);
            SaveProjectCommand = new SaveProjectCommand(this);
            FileMenuItemCommand = new FileMenuItemCommand(this);
            EditMenuItemCommand = new EditMenuItemCommand(this);
            AddTranslatedLineCommand = new AddTranslatedLineCommand(this);
            ExportTxtCommand = new ExportTxtCommand(this);
            SwapLanguageCommand = new SwapLanguageCommand(this);
            ClipboardCommand = new ClipboardCommand(this);
        }

        public ICommand LoadSubsCommand { get; }
        public ICommand NextLineCommand { get; }
        public ICommand PreviousLineCommand { get; }
        public ICommand SplitPartCommand { get; }
        public ICommand CreateProjectCommand { get; }
        public ICommand SubtitlesMenuItemCommand { get; }
        public ICommand FileMenuItemCommand { get; }
        public ICommand EditMenuItemCommand { get; }
        public ICommand SaveProjectCommand { get; }
        public ICommand AddTranslatedLineCommand { get; }
        public ICommand ExportTxtCommand { get; }
        public ICommand SwapLanguageCommand { get; }
        public ICommand ClipboardCommand { get; }

        Translator translator = new Translator();

        private string _translationToolTip = "What translating?";
        public string TranslationToolTip
        {
            get
            {
                return _translationToolTip;
            }
            set
            {
                _translationToolTip = value;
                OnPropertyChanged();
            }
        }

        private string _translatorField = "en";
        public string TranslatorField
        {
            get
            {
                return _translatorField;
            }
            set
            {
                _translatorField = value;
                OnPropertyChanged();
            }
        }
        private string _translatorResultField = "ru";
        public string TranslatorResultField
        {
            get
            {
                return _translatorResultField;
            }
            set
            {
                _translatorResultField = value;
                OnPropertyChanged();
            }
        }
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        private string _result;
        public string Result
        {
            get
            {
                return translator.TranslateText(TranslatorField, TranslatorResultField, Message);
            }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }


        private bool _isProjectCreated = false;
        public bool IsProjectCreated
        {
            get
            {
                return _isProjectCreated;
            }
            set
            {
                _isProjectCreated = value;
                OnPropertyChanged();
            }
        }


        private int _currentSelectedIndex;
        public int CurrentSelectedIndex
        {
            get
            {
                return _currentSelectedIndex;
            }
            set
            {
                _currentSelectedIndex = value;
                OnPropertyChanged();
            }
        }


        private List<string> _subs;
        public List<string> Subs
        {
            get 
            { 
                return _subs; 
            }
            set 
            { 
                _subs = value; 
                OnPropertyChanged(); 
            }
        }

        private List<string> _yourpart;
        public List<string> YourPart
        {
            get
            {
                return _yourpart;
            }
            set
            {
                _yourpart = value;
                OnPropertyChanged();
            }
        }

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
                _isTranslationEnded  = value;
                OnPropertyChanged();
            }
        }


        private int _countOfSubs;
        public int CountOfSubs
        {
            get
            {
                return _countOfSubs;
            }
            set
            {
                _countOfSubs = value;
                OnPropertyChanged();
            }
        }

        private string[] _translatedText;
        public string[] TranslatedText
        {
            get
            {
                return _translatedText;
            }
            set
            {
                _translatedText = value;
                OnPropertyChanged();
            }
        }
    }
}
