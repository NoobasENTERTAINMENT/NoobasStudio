using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands
{
    public class SwapLanguageCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        public SwapLanguageCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            string temp = _globalViewModel.TranslatorResultField;
            _globalViewModel.TranslatorResultField = _globalViewModel.TranslatorField;
            _globalViewModel.TranslatorField = temp;
            if (_globalViewModel.TranslatorField == "ru")
                _globalViewModel.TranslationToolTip = "Что переведем?";
            else
                _globalViewModel.TranslationToolTip = "What translating?";
        }
    }
}
