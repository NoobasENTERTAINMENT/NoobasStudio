using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Win32;
using NoobasStudio.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Shapes;

namespace NoobasStudio.Models
{
    public class Subs
    {
        private List<string> SubsText;
        public List<string> LoadSubs()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt; *.docx; *.doc; *.pdf; *.rtf|*.txt; *.docx; *.doc; *.pdf; *.rtf";
            ofd.Title = "Load subtitles";
            ofd.RestoreDirectory = true;
            ofd.ShowDialog();

            string FilePath = ofd.FileName;
            FileInfo file = new FileInfo(FilePath);

            switch (file.Extension)
            {
                case ".txt":
                    SubsText = GetSubsFromText(FilePath, file);
                    break;
                case ".doc":
                    SubsText = GetSubsFromWord(FilePath);
                    break;
                case ".docx":
                    SubsText = GetSubsFromWord(FilePath);
                    break;
                case ".pdf":
                    SubsText = GetSubsFromPDF(FilePath);
                    break;
                case ".rtf":
                    SubsText = GetSubsFromRTF(FilePath);
                    break;
            }
            SubsText = SplitLongString(SubsText);
            return SubsText;
        }

        private List<string> SplitLongString(List<string> subsText)
        {
            string LongLine = null;
            int SpaceCount = 0;

            List<string> result = new List<string>();
            foreach (string line in subsText.ToArray())
            {
                if (line.Length > 45)
                {
                    int indexOfLongLine = subsText.IndexOf(line);
                    LongLine = line;
                    for (int i = 0; i < LongLine.Length; i++)
                    {
                        if (LongLine[i] == ' ')
                        {
                            SpaceCount++;
                            if (SpaceCount == 6)
                            {
                                LongLine = LongLine.Remove(i, 1).Insert(i, '\n'.ToString()); 
                                SpaceCount = 0;
                            }
                        }
                    }
                    result = LongLine.Split('\n').ToList();

                    int indexOfLastResultElem = result.Count - 1;
                    subsText.RemoveAt(indexOfLongLine);

                    foreach (string resultElem in result)
                    {
                        subsText.Insert(indexOfLongLine, resultElem);
                        indexOfLongLine++;
                    }               
                }
            }
            return subsText.Where(x => x != String.Empty && x != null).ToList();
        }

        private List<string> GetSubsFromRTF(string filePath)
        {
            return GetSubsFromWord(filePath);
        }

        private List<string> GetSubsFromPDF(string FilePath)
        {
            using (PdfReader reader = new PdfReader(FilePath))
            {
                StringBuilder text = new StringBuilder();
                List<string> SubsText = new List<string>();
                bool isCyrillic = false;
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string page = "";
                    page = PdfTextExtractor.GetTextFromPage(reader, i);
                    string[] lines = page.Split('\n').Where(x => x != "" && x.Trim() != String.Empty).ToArray();
                    foreach (string line in lines)
                        SubsText.Add(line);
                }

                foreach (string line in SubsText)
                {
                    if (IsRu(line))
                    {
                        isCyrillic = true;
                        break;
                    }
                    else isCyrillic = false;
                }

                if (isCyrillic || SubsText == null || SubsText.Count == 0)
                {
                    throw new InvalidSubsException();
                }

                return SubsText;
            }
        }

        private List<string> GetSubsFromWord(string FilePath)
        {
            List<string> SubsText = new List<string>();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = FilePath;
            object readOnly = true;
            bool isCyrillic = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                string line = docs.Paragraphs[i + 1].Range.Text.ToString();
                if (line.Contains("\r"))
                    line = line.Replace("\r", string.Empty);
                SubsText.Add(line);
            }

            SubsText = SubsText.Where(x => x != "").ToList();

            foreach (string line in SubsText)
            {
                if (IsRu(line))
                {
                    isCyrillic = true;
                    break;
                }
                else isCyrillic = false;
            }

            if (isCyrillic || SubsText == null || SubsText.Count == 0)
            {
                throw new InvalidSubsException();
            }

            return SubsText;
        }

        private List<string> GetSubsFromText(string FilePath, FileInfo file)
        {
            List<string> SubsText;

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
