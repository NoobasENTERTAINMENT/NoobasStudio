using NoobasStudio.Core;
using NoobasStudio.ViewModels;
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
            if (_projectData.IsHaveUnsavedChanges(_globalViewModel))
            {
                var result = MessageBox.Show($"Save changes to {_projectData.Title}.json?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _projectData.SaveJSON(_globalViewModel);
                }
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            _projectData.CreateJSON(_globalViewModel); 
        }
    }
}
