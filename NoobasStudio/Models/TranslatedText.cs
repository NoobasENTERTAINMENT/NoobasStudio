using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Models
{
    public class TranslatedText
    {
        List<string> translatedText = new List<string>();
        public void AddLine(string Line)
        {
            translatedText.Add(Line);
        }
    }
}
