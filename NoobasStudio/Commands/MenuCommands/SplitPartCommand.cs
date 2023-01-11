using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands
{
    public class SplitPartCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        readonly SplitEnglishSubs _splitEnglishSubs = new SplitEnglishSubs();
        public SplitPartCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            _globalViewModel.Subs = _splitEnglishSubs.SplitTextToParts(_globalViewModel.Subs, parameter);
            _globalViewModel.CountOfSubs = _globalViewModel.Subs.Count();
        }
    }
}
