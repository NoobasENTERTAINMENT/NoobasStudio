using Newtonsoft.Json;
using NoobasStudio.Core;
using NoobasStudio.ViewModels.MergeJSON;
using NoobasStudio.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace NoobasStudio.Models
{
    public class MergingJsons
    {
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

                string jsonString = File.ReadAllText(ofd.FileName);
                ProjectData projectData = JsonConvert.DeserializeObject<ProjectData>(jsonString);

                if (projectData.Progress >= 100)
                {
                    switch (Convert.ToInt32(parameter))
                    {
                        case 1:
                            viewModel.ImageSourceFirstCell = new BitmapImage(new Uri("\\Images\\book.png", UriKind.Relative));
                            viewModel.FirstCellToolTip = projectData.Title;
                            break;
                        case 2:
                            viewModel.ImageSourceSecondCell = new BitmapImage(new Uri("\\Images\\book.png", UriKind.Relative));
                            viewModel.SecondCellToolTip = projectData.Title;
                            break;
                        case 3:
                            viewModel.ImageSourceThirdCell = new BitmapImage(new Uri("\\Images\\book.png", UriKind.Relative));
                            viewModel.ThirdCellToolTip = projectData.Title;
                            break;
                    }
                    
                    viewModel.Jsons[Convert.ToInt32(parameter)-1] = projectData;
                }
            }
            catch (Exception)
            {
                return;
            }   
        }
    }
}
