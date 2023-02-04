using Newtonsoft.Json;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NoobasStudio.Core
{
    public class ProjectData
    {
        public string Title { get; set; }
        public List<string> Subs { get; set; }
        public List<string> YourPart { get; set; }
        public string[] TranslatedText { get; set; }
        public int CurrentSelectedIndex { get; set; }
        public string Part { get; set; }
        public int Progress { get; set; }
        public bool IsProjectCreated { get; set; }
        public bool IsTranslationEnded { get; set; }
        public int CountOfSubs { get; set; }
        public string PathOfProject { get; set; }

        public void CreateJSON(GlobalViewModel globalViewModel)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "*.json|*.json";
                saveFileDialog.Title = "Choose path of project";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.ShowDialog();

                Title = Path.GetFileName(saveFileDialog.FileName);
                Subs = null;
                YourPart = null;
                TranslatedText = null;
                CurrentSelectedIndex = 0;
                Part = null;
                Progress = 0;
                IsProjectCreated = true;
                IsTranslationEnded = true;
                CountOfSubs = 0;
                PathOfProject = saveFileDialog.FileName;

                using (StreamWriter file = File.CreateText(saveFileDialog.FileName))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Serialize(file, this);
                }

                string jsonString = File.ReadAllText(PathOfProject);
                ProjectData projectData = JsonConvert.DeserializeObject<ProjectData>(jsonString);

                globalViewModel.ProjectName = Title = projectData.Title;
                globalViewModel.YourPart = YourPart = projectData.YourPart;
                globalViewModel.Subs = Subs = projectData.Subs;
                globalViewModel.TranslatedText = TranslatedText = projectData.TranslatedText;
                globalViewModel.CurrentSelectedIndex = CurrentSelectedIndex = projectData.CurrentSelectedIndex;
                globalViewModel.Part = Part = projectData.Part;
                globalViewModel.IsProjectCreated = IsProjectCreated = projectData.IsProjectCreated;
                globalViewModel.IsTranslationEnded = IsTranslationEnded = projectData.IsTranslationEnded;
                globalViewModel.CountOfSubs = CountOfSubs = projectData.CountOfSubs;
                globalViewModel.PathOfProject = PathOfProject = projectData.PathOfProject;
                Progress = projectData.Progress;

                globalViewModel.JsonForCompare = JsonConvert.SerializeObject(this);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void SaveJSON(GlobalViewModel globalViewModel)
        {
            try
            {
                Title = Path.GetFileName(globalViewModel.ProjectName);
                Subs = globalViewModel.Subs;
                YourPart = globalViewModel.YourPart;
                TranslatedText = globalViewModel.TranslatedText;
                CurrentSelectedIndex = globalViewModel.CurrentSelectedIndex;
                Part = globalViewModel.Part;
                Progress = Convert.ToInt32(Convert.ToDouble(CurrentSelectedIndex+1) / Convert.ToDouble(YourPart.Count) * 100);
                IsProjectCreated = globalViewModel.IsProjectCreated;
                IsTranslationEnded = globalViewModel.IsTranslationEnded;
                CountOfSubs = globalViewModel.CountOfSubs;
                PathOfProject = globalViewModel.PathOfProject;

                FileStream createStream = File.Create(globalViewModel.PathOfProject);
                System.Text.Json.JsonSerializer.Serialize(createStream, this);
                createStream.Dispose();
                globalViewModel.JsonForCompare = JsonConvert.SerializeObject(this);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void LoadJSON(GlobalViewModel globalViewModel)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "*.json|*.json";
                ofd.Title = "Load project";
                ofd.RestoreDirectory = true;
                ofd.ShowDialog();

                string jsonString = File.ReadAllText(ofd.FileName);
                ProjectData projectData = JsonConvert.DeserializeObject<ProjectData>(jsonString);

                globalViewModel.ProjectName = Title = projectData.Title;
                globalViewModel.YourPart = YourPart = projectData.YourPart;
                globalViewModel.Subs = Subs = projectData.Subs;
                globalViewModel.TranslatedText = TranslatedText = projectData.TranslatedText;
                globalViewModel.CurrentSelectedIndex = CurrentSelectedIndex = projectData.CurrentSelectedIndex;
                globalViewModel.Part = Part = projectData.Part;
                globalViewModel.IsProjectCreated = IsProjectCreated = projectData.IsProjectCreated;
                globalViewModel.IsTranslationEnded = IsTranslationEnded = projectData.IsTranslationEnded;
                globalViewModel.CountOfSubs = CountOfSubs = projectData.CountOfSubs;
                globalViewModel.PathOfProject = PathOfProject = projectData.PathOfProject;
                Progress = projectData.Progress;

                globalViewModel.JsonForCompare = JsonConvert.SerializeObject(this); ;
            }
            catch(Exception)
            {
                return;
            }
        }
        public bool IsHaveUnsavedChanges(GlobalViewModel globalViewModel)
        {
            if(globalViewModel.IsProjectCreated == true && globalViewModel.YourPart != null)
            {
                Title = Path.GetFileName(globalViewModel.ProjectName);
                Subs = globalViewModel.Subs;
                YourPart = globalViewModel.YourPart;
                TranslatedText = globalViewModel.TranslatedText;
                CurrentSelectedIndex = globalViewModel.CurrentSelectedIndex;
                Part = globalViewModel.Part;
                Progress = Convert.ToInt32(Convert.ToDouble(CurrentSelectedIndex+1) / Convert.ToDouble(YourPart.Count) * 100);
                IsProjectCreated = globalViewModel.IsProjectCreated;
                IsTranslationEnded = globalViewModel.IsTranslationEnded;
                CountOfSubs = globalViewModel.CountOfSubs;
                PathOfProject = globalViewModel.PathOfProject;

                string jsonCurrent = JsonConvert.SerializeObject(this);

                bool result = jsonCurrent != globalViewModel.JsonForCompare ? true : false;

                if (result)
                    globalViewModel.StarText = "*";
                else
                    globalViewModel.StarText = string.Empty;

                return result;
            }   
            return false;
        }
    }
    
}
