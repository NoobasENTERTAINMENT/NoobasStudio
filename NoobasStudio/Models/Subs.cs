using Microsoft.Win32;
using NoobasStudio.Exceptions;
using NoobasStudio.ViewModels;
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
        private List<string> SubsText;
        public List<string> LoadSubs()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            
            string RealFileName = ofd.SafeFileName;
            string FilePath = ofd.FileName;

            var file = new FileInfo(FilePath);
            string AllText = File.ReadAllText(FilePath);

            SubsText = File.ReadAllLines(FilePath).ToList();
            SubsText = SubsText.Where(x => x != "").ToList();

            if (IsRu(AllText) || file.Length == 0 || AllText.Trim() == string.Empty)
            {
                throw new InvalidSubsException();
            }
            return SubsText;

        }

        private bool IsRu(string subsText)
        {
            return Regex.IsMatch(subsText, @"\p{IsCyrillic}");
        }
    }
}
