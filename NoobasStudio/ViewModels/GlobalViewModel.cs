using NoobasStudio.Commands;
using NoobasStudio.Commands.MenuCommands;
using NoobasStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        private int _currentSelectedItem;
        public int CurrentSelectedItem
        {
            get
            {
                return _currentSelectedItem;
            }
            set
            {
                _currentSelectedItem = value;
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


        private bool _isTranslationEnded;
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
    }
}
