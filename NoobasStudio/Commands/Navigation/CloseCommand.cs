using NoobasStudio.Core;
using NoobasStudio.ViewModels;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace NoobasStudio.Commands
{
    public class CloseCommand : CommandBase
    {
        private readonly GlobalViewModel _globalViewModel;
        private ProjectData _projectData;
        public CloseCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _projectData = new ProjectData();
        }
        public override void Execute(object parameter)
        {
            bool isHaveUnsavedChanges = _projectData.IsHaveUnsavedChanges(_globalViewModel);
            if (isHaveUnsavedChanges)
            {
                DialogResult dialogResult = MessageBox.Show($"Save changes to {_projectData.Title}.json?", 
                    "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    _projectData.SaveJSON(_globalViewModel);
                }
                else if (dialogResult == DialogResult.Cancel)
                    return;
            }
            System.Windows.Application.Current.Shutdown();
        }
    }
}
