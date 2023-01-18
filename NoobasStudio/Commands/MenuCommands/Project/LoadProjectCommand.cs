using NoobasStudio.Core;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Commands.MenuCommands.Project
{
    public class LoadProjectCommand : CommandBase
    {
        readonly private GlobalViewModel _globalViewModel;
        readonly private ProjectData _projectData;
        public LoadProjectCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _projectData = new ProjectData();
        }
        public override void Execute(object parameter)
        {
            _projectData.LoadJSON(_globalViewModel);
        }
    }
}
