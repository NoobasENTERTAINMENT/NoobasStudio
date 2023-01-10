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
        GlobalViewModel _globalViewModel;
        SplitEnglishSubs split = new SplitEnglishSubs();

        public SplitPartCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }

        public override void Execute(object parameter)
        {
            split.SplitTextToParts(_globalViewModel.Subs , 1);
        }
    }
}
