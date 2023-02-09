using NoobasStudio.Exceptions;
using NoobasStudio.Models;
using NoobasStudio.ViewModels;
using System;
using System.Windows;

namespace NoobasStudio.Commands
{
    public class LoadSubsCommand : CommandBase
    {
        Subs subs = new Subs();
        System.Diagnostics.Process[] aProcWrd;
        GlobalViewModel _globalViewModel;
        public LoadSubsCommand(GlobalViewModel globalViewModel)
        {
            _globalViewModel = globalViewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                _globalViewModel.IsTranslationEnded = false;

                _globalViewModel.Subs = _globalViewModel.YourPart = subs.LoadSubs();

                _globalViewModel.CountOfSubs = _globalViewModel.Subs.Count - 1;
                _globalViewModel.TranslatedText = new string[_globalViewModel.CountOfSubs + 1];

                TerminateWordProcess(aProcWrd);
            }
            catch (InvalidSubsException)
            {
                TerminateWordProcess(aProcWrd);
                MessageBox.Show("Cyrillic and empty file are not allowed", "Loading subtitles error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (Exception)
            {
                TerminateWordProcess(aProcWrd);
                MessageBox.Show("Unexpected error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        public void TerminateWordProcess(System.Diagnostics.Process[] aProcWrd)
        {
            aProcWrd = System.Diagnostics.Process.GetProcessesByName("WINWORD");

            foreach (System.Diagnostics.Process oProc in aProcWrd)
            {
                oProc.Kill();
            }
        }
    }
}
