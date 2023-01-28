using NoobasStudio.Models;
using NoobasStudio.ViewModels.MergeJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.AnvilCommands
{
    public class UnloadFinalJsonCommand : CommandBase
    {
        private readonly MergeJSONViewModel _mergeJSONViewModel;
        public UnloadFinalJsonCommand(MergeJSONViewModel mergeJSONViewModel)
        {
            _mergeJSONViewModel = mergeJSONViewModel;
        }
        public override void Execute(object parameter)
        {
        }
    }
}
