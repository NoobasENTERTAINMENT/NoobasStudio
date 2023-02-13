using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.MenuCommands.Edit
{
    public class FOVLinesCommand : CommandBase
    {
        private readonly GlobalViewModel _globalViewModel;
        public FOVLinesCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            switch (parameter)
            {
                case "3":
                    _globalViewModel.HeightListBox = 130;
                    _globalViewModel.FontSize = 25; 
                    break;
                case "5":
                    _globalViewModel.HeightListBox = 190;
                    _globalViewModel.FontSize = 23;
                    break;
                case "7":
                    _globalViewModel.HeightListBox = 230;
                    _globalViewModel.FontSize = 20; 
                    break;
            }
        }
    }
}
