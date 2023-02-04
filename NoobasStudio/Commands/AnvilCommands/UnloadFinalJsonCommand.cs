using NoobasStudio.Core;
using NoobasStudio.Models;
using NoobasStudio.ViewModels.MergeJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoobasStudio.Commands.AnvilCommands
{
    public class UnloadFinalJsonCommand : CommandBase
    {
        private readonly MergeJSONViewModel _mergeJSONViewModel;
        public UnloadFinalJsonCommand(MergeJSONViewModel mergeJSONViewModel)
        {
            _mergeJSONViewModel = mergeJSONViewModel;
        }
        public override void Execute(object parameter)
        {
            int CountOfNulls = 0;
            foreach (var item in _mergeJSONViewModel.Jsons)
            {
                if (item == null)
                    CountOfNulls++;
            }

            if (CountOfNulls > 1)
            {
                _mergeJSONViewModel.CrossVisibility = System.Windows.Visibility.Visible;
                _mergeJSONViewModel.MessageText = "Load JSON's!";
                _mergeJSONViewModel.MessageVisibility = System.Windows.Visibility.Visible;
            }
            else if (_mergeJSONViewModel.NewFileName == null || _mergeJSONViewModel.NewFileName.Trim() == String.Empty)
            {
                _mergeJSONViewModel.CrossVisibility = System.Windows.Visibility.Visible;
                _mergeJSONViewModel.MessageText = "Write new file name!";
                _mergeJSONViewModel.MessageVisibility = System.Windows.Visibility.Visible;
            }
            else
            {
                _mergeJSONViewModel.CrossVisibility = System.Windows.Visibility.Hidden;
                _mergeJSONViewModel.MessageText = "";
                _mergeJSONViewModel.MessageVisibility = System.Windows.Visibility.Hidden;
                try
                {
                    string[] firstTranslation = null;
                    string[] secondTranslation = null;
                    string[] thirdTranslation = null;
                    string[] fullTranslation = null;


                    if (CountOfNulls == 1)
                    {
                        _mergeJSONViewModel.Jsons = _mergeJSONViewModel.Jsons.Where(x => x != null).ToArray();

                        for (int i = 0; i < _mergeJSONViewModel.Jsons.Length; i++)
                        {
                            if (_mergeJSONViewModel.Jsons[i].Part == "2 person 1 part")
                            {
                                firstTranslation = _mergeJSONViewModel.Jsons[i].TranslatedText;
                            }
                            if (_mergeJSONViewModel.Jsons[i].Part == "2 person 2 part")
                            {
                                secondTranslation = _mergeJSONViewModel.Jsons[i].TranslatedText;
                            }  
                        }
                        fullTranslation = new string[firstTranslation.Length + secondTranslation.Length];
                        Array.Copy(firstTranslation, fullTranslation, firstTranslation.Length);
                        Array.Copy(secondTranslation, 0, fullTranslation, firstTranslation.Length, secondTranslation.Length);
                    }
                    if (CountOfNulls == 0)
                    {

                    }


                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "*.txt|*.txt";
                    saveFileDialog.Title = "Export translation from merged JSON";
                    saveFileDialog.FileName = _mergeJSONViewModel.NewFileName;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.ShowDialog();
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (string str in fullTranslation)
                            writer.WriteLine(str);
                    }
                }
                catch (Exception)
                {
                    return;
                }
                
            }
        }
    }
}
