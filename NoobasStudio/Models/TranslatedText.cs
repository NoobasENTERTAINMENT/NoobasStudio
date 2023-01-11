using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Models
{
    public class TranslatedText
    {
        public string[] translatedText;
        public TranslatedText(int capacity)
        {
            translatedText = new string[capacity];
        }
    }
}
