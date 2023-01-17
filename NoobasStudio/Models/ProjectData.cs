using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoobasStudio.Core
{
    public class ProjectData
    {
        public string Title { get; set; }
        public List<string> Subs { get; set; }
        public string[] TranslatedText { get; set; }
        public int CurrentSelectedIndex { get; set; }
        public string Part { get; set; }
        public int Progress { get; set; } 

        public void CreateJSON(GlobalViewModel globalViewModel)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.json|*.json";
            saveFileDialog.Title = "Choose path of project";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();

            Title = Path.GetFileName(saveFileDialog.FileName);
            Subs = globalViewModel.YourPart;
            TranslatedText = globalViewModel.TranslatedText;
            CurrentSelectedIndex = globalViewModel.CurrentSelectedIndex;
            Part = globalViewModel.Part;
            Progress = 0;

            using (StreamWriter file = File.CreateText(saveFileDialog.FileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this);
            }

            globalViewModel.IsProjectCreated = true;
            globalViewModel.ProjectName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
            globalViewModel.PathOfProject = saveFileDialog.FileName;
        }
        public void SaveJSON(GlobalViewModel globalViewModel)
        {
            Title = Path.GetFileName(globalViewModel.ProjectName);
            Subs = globalViewModel.YourPart;
            TranslatedText = globalViewModel.TranslatedText;
            CurrentSelectedIndex = globalViewModel.CurrentSelectedIndex;
            Part = globalViewModel.Part;
            Progress = Convert.ToInt32(Convert.ToDouble(CurrentSelectedIndex) / Convert.ToDouble(Subs.Count) * 100);

            string result = string.Empty;
            using (StreamReader r = new StreamReader(globalViewModel.PathOfProject))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                jobj["Title"] = Title;
                jobj["Subs"] = JsonConvert.SerializeObject(Subs);
                jobj["TranslatedText"] = JsonConvert.SerializeObject(TranslatedText);
                jobj["CurrentSelectedIndex"] = CurrentSelectedIndex;
                jobj["Part"] = Part;
                jobj["Progress"] = Progress;
                result = jobj.ToString();
                Console.WriteLine(result);
            }
            File.WriteAllText(globalViewModel.PathOfProject, result);
        }
    }
}
