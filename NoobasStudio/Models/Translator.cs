using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace NoobasStudio.Models
{
    public class Translator
    {
        private HttpClient httpClient = new HttpClient();
        private JavaScriptSerializer serializer = new JavaScriptSerializer();
        private string translation = "";
        public string TranslateText(string firstLng, string secondLng, string input)
        {
            if(input != null)
            {
                string url = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", firstLng, secondLng, Uri.EscapeUriString(input));
                string result = httpClient.GetStringAsync(url).Result;
                var jsonData = serializer.Deserialize<List<dynamic>>(result);
                var translationItems = jsonData[0]; ;
                foreach (object item in translationItems)
                {
                    IEnumerable translationLineObject = item as IEnumerable;
                    IEnumerator translationLineString = translationLineObject.GetEnumerator();
                    translationLineString.MoveNext();
                    translation = string.Format(" {0}", Convert.ToString(translationLineString.Current));
                }

                return translation;
            }
            else
            {
                return null;
            }
        }
    }
}
