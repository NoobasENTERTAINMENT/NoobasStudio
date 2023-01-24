using NoobasStudio.Models;
using NoobasStudio.ViewModels.MergeJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoobasStudio.Commands.AnvilCommands
{
    public class LoadToCellJsonCommand : CommandBase
    {
        private readonly MergeJSONViewModel _mergeJSONViewModel;
        private readonly MergingJsons _mergingJsons;
        public LoadToCellJsonCommand(MergeJSONViewModel mergeJSONViewModel)
        {
            _mergeJSONViewModel = mergeJSONViewModel;
            _mergingJsons = new MergingJsons();
        }
        public override void Execute(object parameter)
        {
            _mergingJsons.LoadJsonToCell(_mergeJSONViewModel, parameter);
        }
    }
}
