using NoobasStudio.Commands.AnvilCommands;
using NoobasStudio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NoobasStudio.ViewModels.MergeJSON
{
    public class MergeJSONViewModel : ViewModelBase
    {
        public MergeJSONViewModel()
        {
            LoadToCellJsonCommand = new LoadToCellJsonCommand(this);
            UnloadFinalJsonCommand = new UnloadFinalJsonCommand(this);
        }

        public ICommand LoadToCellJsonCommand { get; }
        public ICommand UnloadFinalJsonCommand { get; }

        private string _newFileName;
        public string NewFileName
        {
            get
            {
                return _newFileName;
            }
            set
            {
                _newFileName = value;
                OnPropertyChanged();
            }
        }

        private BitmapImage _imageSourceFirstCell;
        public BitmapImage ImageSourceFirstCell
        {
            get
            {
                return _imageSourceFirstCell;
            }
            set
            {
                _imageSourceFirstCell = value;
                OnPropertyChanged();
            }
        }

        private BitmapImage _imageSourceSecondCell;
        public BitmapImage ImageSourceSecondCell
        {
            get
            {
                return _imageSourceSecondCell;
            }
            set
            {
                _imageSourceSecondCell = value;
                OnPropertyChanged();
            }
        }

        private BitmapImage _imageSourceThirdCell;
        public BitmapImage ImageSourceThirdCell
        {
            get
            {
                return _imageSourceThirdCell;
            }
            set
            {
                _imageSourceThirdCell = value;
                OnPropertyChanged();
            }
        }

        private Visibility _finalJsonImageVisibility = Visibility.Hidden;
        public Visibility FinalJsonImageVisibility
        {
            get
            {
                return _finalJsonImageVisibility;
            }
            set
            {
                _finalJsonImageVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _crossVisibility = Visibility.Hidden;
        public Visibility CrossVisibility
        {
            get
            {
                return _crossVisibility;
            }
            set
            {
                _crossVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _messageVisibility = Visibility.Hidden;
        public Visibility MessageVisibility
        {
            get
            {
                return _messageVisibility;
            }
            set
            {
                _messageVisibility = value;
                OnPropertyChanged();
            }
        }

        private string _messageText = "Progress in all JSON must be 100%";
        public string MessageText
        {
            get
            {
                return _messageText;
            }
            set
            {
                _messageText = value;
                OnPropertyChanged();
            }
        }

        private string _firstCellToolTip;
        public string FirstCellToolTip
        {
            get
            {
                return _firstCellToolTip;
            }
            set
            {
                _firstCellToolTip = value;
                OnPropertyChanged();
            }
        }

        private string _secondCellToolTip;
        public string SecondCellToolTip
        {
            get
            {
                return _secondCellToolTip;
            }
            set
            {
                _secondCellToolTip = value;
                OnPropertyChanged();
            }
        }

        private string _thirdCellToolTip;
        public string ThirdCellToolTip
        {
            get
            {
                return _thirdCellToolTip;
            }
            set
            {
                _thirdCellToolTip = value;
                OnPropertyChanged();
            }
        }

        private bool _thirdCellIsEnabled = false;
        public bool ThirdCellIsEnabled
        {
            get
            {
                return _thirdCellIsEnabled;
            }
            set
            {
                _thirdCellIsEnabled = value;
                OnPropertyChanged();
            }
        }

        public ProjectData[] Jsons = new ProjectData[3];
    }
}
