using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace NoobasStudio.Models
{
    public class Subs
    {
        public string[] text { get; set; }
        public void LoadSubs()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();                                                                  

                string RealFileName = ofd.SafeFileName; 
                string FilePath = ofd.FileName;

                var file = new FileInfo(FilePath);

                if (file.Length == 0) 
                {                                    
                    MessageBox.Show("Please select a non-empty file!", "Error");
                    return;
                }

                string AllText = File.ReadAllText(FilePath);        

                if (Regex.IsMatch(AllText, @"\p{IsCyrillic}"))             
                {
                    MessageBox.Show("Please select file with english language!", "Error");                                            
                    return;
                }

                else
                {
                    text = File.ReadAllLines(FilePath);
                    text = text.Where(x => x != "").ToArray();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File wasn't be chosen! Try again.", "Error");
                return;
            }
        }
    }
}
