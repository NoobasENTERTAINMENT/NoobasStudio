using System.Collections.Generic;

namespace NoobasStudio.Models
{
    public class SplitEnglishSubs
    {
        readonly List<string> yourPart = new List<string>();
        public List<string> SplitTextToParts(List<string> subs, object part)
        {
            yourPart.Clear();
            switch (part)
            {
                case "2 person 1 part":
                    for (int i = 0; i < subs.Count / 2; i++)
                        yourPart.Add(subs[i]);
                    break;
                case "2 person 2 part":
                    for (int i = subs.Count / 2; i < subs.Count; i++)
                        yourPart.Add(subs[i]);
                    break;
                case "3 person 1 part":
                    for (int i = 0; i < subs.Count / 3; i++)
                        yourPart.Add(subs[i]);
                    break;
                case "3 person 2 part":
                    for (int i = subs.Count / 3; i < subs.Count / 3 * 2; i++)
                        yourPart.Add(subs[i]);
                    break;
                case "3 person 3 part":
                    for (int i = subs.Count / 3 * 2; i < subs.Count / 3 * 3; i++)
                        yourPart.Add(subs[i]);
                    break;
            }
            return yourPart;
        }
    }
}
