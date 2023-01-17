using Microsoft.Win32;
using NoobasStudio.ViewModels;
using NoobasStudio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace NoobasStudio.Commands.MenuCommands
{
    public class ExportTxtCommand : CommandBase
    {
        GlobalViewModel _globalViewModel;
        ExportFileText exportFile = new ExportFileText();
        public ExportTxtCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
            _globalViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_globalViewModel.TranslatedText)
                || e.PropertyName == nameof(_globalViewModel.Translation))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return (_globalViewModel.TranslatedText[0] != null) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            try
            {
                exportFile.ExportFile(_globalViewModel.TranslatedText);
            }
            catch { return; }
        }
    }
}
