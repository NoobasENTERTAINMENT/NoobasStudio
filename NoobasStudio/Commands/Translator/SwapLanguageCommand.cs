using NoobasStudio.ViewModels;

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
            (_globalViewModel.TranslatorField, _globalViewModel.TranslatorResultField) = (_globalViewModel.TranslatorResultField, _globalViewModel.TranslatorField);
            if (_globalViewModel.TranslatorField == "ru")
                _globalViewModel.TranslationToolTip = "Что переведем?";
            else
                _globalViewModel.TranslationToolTip = "What translating?";
        }
    }
}
