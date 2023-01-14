using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Stores
{
    public class NavigationStore
    {
        public event Action BottomFieldViewModelChanged;

        private ViewModelBase _bottomFieldViewModel;
        public ViewModelBase BottomFieldViewModel
        {
            get { return _bottomFieldViewModel; }
            set 
            { 
                _bottomFieldViewModel = value;
                OnBottomFieldViewModelChanged();
            }
        }

        private void OnBottomFieldViewModelChanged()
        {
            BottomFieldViewModelChanged?.Invoke();
        }
    }
}
