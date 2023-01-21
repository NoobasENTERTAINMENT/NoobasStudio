﻿using NoobasStudio.Core;
using NoobasStudio.ViewModels;
using System.Windows.Forms;

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
            bool isHaveUnsavedChanges = _projectData.IsHaveUnsavedChanges(_globalViewModel);
            if (isHaveUnsavedChanges)
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
            _projectData.LoadJSON(_globalViewModel);
        }
    }
}
