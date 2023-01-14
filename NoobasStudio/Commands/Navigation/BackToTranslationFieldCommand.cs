using NoobasStudio.Stores;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.Navigation
{
    internal class BackToTranslationFieldCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly GlobalViewModel _globalViewModel;
        public BackToTranslationFieldCommand(NavigationStore navigationStore, GlobalViewModel globalViewModel)
        {
            _navigationStore = navigationStore;
            _globalViewModel = globalViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.BottomFieldViewModel = new TranslationFieldViewModel(_navigationStore, _globalViewModel);
        }
    }
}
