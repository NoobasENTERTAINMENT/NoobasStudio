using NoobasStudio.Commands;
using NoobasStudio.Commands.SplitPartsCommands;
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
            AddTranslateLineCommand = new AddTranslateLineCommand(this);
            PartOneSplitCommand = new PartOneSplitCommand(this);
        }
        public ICommand LoadSubsCommand { get; }
        public ICommand AddTranslateLineCommand { get; }
        public ICommand NextLineCommand { get; }
        public ICommand PreviousLineCommand { get; }
        public ICommand PartOneSplitCommand { get; }


        private int _currentMenuItem;
        public int CurrentMenuItem
        {
            get
            {
                return _currentMenuItem;
            }
            set
            {
                _currentMenuItem = value;
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
                return _isTranslationEnded = true;
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
