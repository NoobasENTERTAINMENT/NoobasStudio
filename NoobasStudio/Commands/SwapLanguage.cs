using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands
{
    public class SwapLanguage : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        public SwapLanguage(GlobalViewModel globalViewModel)
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
