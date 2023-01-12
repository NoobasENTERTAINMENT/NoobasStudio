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
    public class LoadSubsCommand : CommandBase
    {
        Subs subs = new Subs();
        GlobalViewModel _globalViewModel;
        public LoadSubsCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                _globalViewModel.Subs = subs.LoadSubs();
                _globalViewModel.IsTranslationEnded = false;
                _globalViewModel.CountOfSubs = _globalViewModel.Subs.Count - 1;
                _globalViewModel.TranslatedText = new string[_globalViewModel.CountOfSubs + 1];
            }
            catch (InvalidSubsException)
            {
                MessageBox.Show("Cyrillic and empty file are not allowed", "Loading subtitles error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (ArgumentException)
            {
                
            }
            
        }
    }
}