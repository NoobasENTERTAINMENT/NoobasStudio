using Microsoft.Win32;
using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.MenuCommands.File
{
    public class MergeJsonsCommand : CommandBase
    {
        readonly MergingJsons mergeJsons = new MergingJsons();
        public override void Execute(object parameter)
        {
            mergeJsons.MergeJsonsOpen();
        }
    }
}
