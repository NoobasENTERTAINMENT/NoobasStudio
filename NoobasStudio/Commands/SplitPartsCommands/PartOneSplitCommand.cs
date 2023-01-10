using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.SplitPartsCommands
{
    public class PartOneSplitCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        SplitEnglishSubs _splitEnglishSubs = new SplitEnglishSubs();
        public PartOneSplitCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            _globalViewModel.Subs = _splitEnglishSubs.SplitTextToParts(_globalViewModel.Subs, parameter);

        }
    }
}
