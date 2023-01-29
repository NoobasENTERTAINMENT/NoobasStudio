using Newtonsoft.Json;
using NoobasStudio.Core;
using NoobasStudio.ViewModels.MergeJSON;
using NoobasStudio.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace NoobasStudio.Models
{
    public class MergingJsons
    {
        private string typeOfMerging = null;
        public void MergeJsonsOpen()
        {
            MergeJSONViewModel viewModel = new MergeJSONViewModel();
            CraftGenerealView anvil = new CraftGenerealView();
            anvil.DataContext = viewModel;
            anvil.ShowDialog();
        }

        public void LoadJsonToCell(MergeJSONViewModel viewModel, object parameter)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "*.json|*.json";
                ofd.Title = "Load JSON to merge";
                ofd.RestoreDirectory = true;
                ofd.ShowDialog();

                string jsonLoadedString = File.ReadAllText(ofd.FileName);
                ProjectData loadedJson = JsonConvert.DeserializeObject<ProjectData>(jsonLoadedString);

                if(viewModel.Jsons.All(x => x == null))
                {
                    if (loadedJson.Part.Contains("2 person"))
                        typeOfMerging = "2 person";
                    else
                        typeOfMerging = "3 person";
                }

                if(typeOfMerging == "3 person")
                    viewModel.ThirdCellIsEnabled = true;

                if (typeOfMerging == "3 person" && loadedJson.Part.Contains("2 person"))
                {
                    viewModel.MessageText = "Your JSON must be splitted for 3 person!";
                    viewModel.MessageVisibility = System.Windows.Visibility.Visible;
                    return;
                }
                if (typeOfMerging == "2 person" && loadedJson.Part.Contains("3 person"))
                {
                    viewModel.MessageText = "Your JSON must be splitted for 2 person!";
                    viewModel.MessageVisibility = System.Windows.Visibility.Visible;
                    return;
                }

                bool isRepeat = false;

                foreach(ProjectData item in viewModel.Jsons)
                {
                    if(item != null)
                    {
                        string jsonInList = JsonConvert.SerializeObject(item);
                        string jsonLoaded = JsonConvert.SerializeObject(loadedJson);

                        if (jsonInList.Equals(jsonLoaded))
                        {
                            isRepeat = true;

                            viewModel.MessageText = "This JSON is already exists in cells!";
                            viewModel.MessageVisibility = System.Windows.Visibility.Visible;

                            break;
                        }

                        if (item.Part == loadedJson.Part)
                        {
                            isRepeat = true;

                            viewModel.MessageText = "You need load JSON's with different parts!";
                            viewModel.MessageVisibility = System.Windows.Visibility.Visible;

                            break;
                        }
                    }
                    
                }
                if (loadedJson.Progress < 100)
                {
                    viewModel.CrossVisibility = System.Windows.Visibility.Visible;
                    viewModel.MessageText = "Progress in your JSON must be 100%!";
                    viewModel.MessageVisibility = System.Windows.Visibility.Visible;
                }

                if (loadedJson.Progress >= 100 && !isRepeat)
                {
                    viewModel.CrossVisibility = System.Windows.Visibility.Hidden;
                    viewModel.MessageText = "";
                    viewModel.MessageVisibility = System.Windows.Visibility.Hidden;

                    switch (Convert.ToInt32(parameter))
                    {
                        case 1:
                            viewModel.ImageSourceFirstCell = new BitmapImage(new Uri("\\Images\\book.png", UriKind.Relative));
                            viewModel.FirstCellToolTip = loadedJson.Title;
                            break;
                        case 2:
                            viewModel.ImageSourceSecondCell = new BitmapImage(new Uri("\\Images\\book.png", UriKind.Relative));
                            viewModel.SecondCellToolTip = loadedJson.Title;
                            break;
                        case 3:
                            viewModel.ImageSourceThirdCell = new BitmapImage(new Uri("\\Images\\book.png", UriKind.Relative));
                            viewModel.ThirdCellToolTip = loadedJson.Title;
                            break;
                    }
                    
                    viewModel.Jsons[Convert.ToInt32(parameter)-1] = loadedJson;
                }

                int CountOfNulls = 0;
                foreach (var item in viewModel.Jsons)
                {
                    if(item == null)
                        CountOfNulls++;
                }
                if (CountOfNulls < 2)
                {
                    viewModel.FinalJsonImageVisibility = System.Windows.Visibility.Visible;
                }
            }
            catch (Exception)
            {
                return;
            }   
        }
    }
}
