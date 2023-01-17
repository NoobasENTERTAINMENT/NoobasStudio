using Newtonsoft.Json;
using NoobasStudio.Core;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoobasStudio.Commands
{
    public class CreateProjectCommand : CommandBase
    {
        readonly GlobalViewModel _globalViewModel;
        private ProjectData _projectData;
        public CreateProjectCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _projectData = new ProjectData();
        }
        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            try
            {
                _projectData.CreateJSON(_globalViewModel);
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
}
