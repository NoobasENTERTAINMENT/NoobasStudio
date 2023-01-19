using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Linq;

namespace NoobasStudio.Commands
{
    public class SplitPartCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        SplitEnglishSubs _splitEnglishSubs = new SplitEnglishSubs();
        public SplitPartCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                _globalViewModel.YourPart = null;
                _globalViewModel.YourPart = _splitEnglishSubs.SplitTextToParts(_globalViewModel.Subs, parameter);
                _globalViewModel.CountOfSubs = _globalViewModel.YourPart.Count();
                _globalViewModel.TranslatedText = new string[_globalViewModel.CountOfSubs + 1];
                _globalViewModel.CurrentSelectedIndex = 0;
                _globalViewModel.Part = parameter.ToString();
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
}
