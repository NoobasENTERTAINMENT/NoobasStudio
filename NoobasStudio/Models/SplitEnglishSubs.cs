using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Models
{
    public class SplitEnglishSubs
    {
        readonly List<string> yourPart = new List<string>();
        public List<string> SplitTextToParts(List<string> subs, object part)
        {
            switch (part)
            {
                case "1":
                    for (int i = 0; i < subs.Count / 2; i++)
                        yourPart.Add(subs[i]);
                    break;
                case "2":
                    for (int i = subs.Count / 2; i < subs.Count; i++)
                        yourPart.Add(subs[i]);
                    break;
                case "3":
                    for (int i = 0; i < subs.Count / 3; i++)
                        yourPart.Add(subs[i]);
                    break;
                case "4":
                    for (int i = subs.Count / 3; i < subs.Count / 3 * 2; i++)
                        yourPart.Add(subs[i]);
                    break;
                case "5":
                    for (int i = subs.Count / 3 * 2; i < subs.Count / 3 * 3; i++)
                        yourPart.Add(subs[i]);
                    break;
            }
            return yourPart;
        }
    }
}
