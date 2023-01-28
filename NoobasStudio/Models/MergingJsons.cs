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
        
        private DispatcherTimer _timer = new DispatcherTimer();
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

                bool isRepeat = false;

                foreach(ProjectData item in viewModel.Jsons)
                {
                    if(item != null)
                    {
                        string json1 = JsonConvert.SerializeObject(item);
                        string json2 = JsonConvert.SerializeObject(projectData);
                        if (json1.Equals(json2))
                        {
                            isRepeat = true;

                            EventHandler eventHandler = (sender, e) => timer_Tick(sender, e, viewModel);
                            _timer.Tick += eventHandler;
                            _timer.Interval = new TimeSpan(0, 0, 0, 0, 1500);
                            _timer.Start();
                            viewModel.CrossVisibility = System.Windows.Visibility.Visible;
                            viewModel.MessageText = "This JSON is already exists in cells!";
                            viewModel.MessageVisibility = System.Windows.Visibility.Visible;

                            break;
                        }
                    } 
                }
                if (projectData.Progress < 100)
                {
                    EventHandler eventHandler = (sender, e) => timer_Tick(sender, e, viewModel);
                    _timer.Tick += eventHandler;
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 1500);
                    _timer.Start();
                    viewModel.CrossVisibility = System.Windows.Visibility.Visible;
                    viewModel.MessageText = "Progress in your JSON must be 100%!";
                    viewModel.MessageVisibility = System.Windows.Visibility.Visible;
                }

                if (projectData.Progress >= 100 && !isRepeat)
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

        private void timer_Tick(object sender, EventArgs e, MergeJSONViewModel viewModel)
        {
            viewModel.CrossVisibility = System.Windows.Visibility.Hidden;
            viewModel.MessageText = "";
            viewModel.MessageVisibility = System.Windows.Visibility.Hidden;
        }
    }
}
