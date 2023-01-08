﻿using NoobasStudio.Exceptions;
using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NoobasStudio.Commands
{
    public class LoadFileCommand : CommandBase
    {
        Subs subs = new Subs();
        GlobalViewModel _globalViewModel;
        public LoadFileCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                _globalViewModel.Subs = subs.LoadSubs();
            }
            catch (InvalidSubsException)
            {
                MessageBox.Show("Cyrillic or white space or empty file is not allowed.", "Loading subtitles error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
