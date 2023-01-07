using NoobasStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands
{
    public class LoadFileCommand : CommandBase
    {
        Subs subs = new Subs();
        public override void Execute(object parameter)
        {
            subs.LoadSubs();
        }
    }
}
