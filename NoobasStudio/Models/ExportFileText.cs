using Microsoft.Win32;
using NoobasStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Models
{
    public class ExportFileText
    {
        public void ExportFile(string[] translatedText)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.txt|*.txt";
            saveFileDialog.Title = "Export Translation";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
            {
                foreach (string str in translatedText)
                    writer.WriteLine(str);
            }
        }
    }
}
