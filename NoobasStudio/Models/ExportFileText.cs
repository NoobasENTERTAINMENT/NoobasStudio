using Microsoft.Win32;
using System.IO;

namespace NoobasStudio.Models
{
    public class ExportFileText
    {
        public void ExportFile(string[] translatedText)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.txt|*.txt";
            saveFileDialog.Title = "Export translation";
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
