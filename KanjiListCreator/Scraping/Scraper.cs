using KanjiListCreator.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KanjiListCreator.Scraping
{
    public class Scraper
    {
        public string GetHtmlFromUrl(string url)
        {
            string htmlBody = "";

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            htmlBody = reader.ReadToEnd();

            return htmlBody;
        }

        public List<ScrapedKanji> GetKanjiFromPage(string htmlBody, string jlpt_level = "")
        {
            List<ScrapedKanji> result = new List<ScrapedKanji>();

            string[] grabTable = htmlBody.Split(new string[] { "<th>Kanji</th>" }, StringSplitOptions.RemoveEmptyEntries);
            string[] splitRows = grabTable[1].Split(new string[] { "<tr><td>" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string row in splitRows)
            {
                List<string> attributes = new List<string>();
                if (row.Substring(0, 5).Equals("</td>"))
                {
                    attributes.Add("");
                }

                if (row.Contains("<td>"))
                {
                    string[] splitColumns = row.Split(new string[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);


                    foreach (string splitColumn in splitColumns)
                    {
                        string column = splitColumn;
                        string value = "";
                        int tag = 0;
                        if (column.Contains("<td>"))
                        {
                            tag = column.IndexOf('>');
                            column = column.Substring(tag + 1);
                        }

                        tag = column.IndexOf('>');
                        if (tag > 0)
                        {
                            column = column.Substring(tag + 1);
                            tag = column.IndexOf('<');
                            if (tag > 0)
                            {
                                value = column.Substring(0, tag);
                                attributes.Add(value);
                            }

                        }


                    }

                    if (attributes.Count == 3)
                    {
                        if (attributes[0].Equals(""))
                        {
                            result.Add(new ScrapedKanji { Word = attributes[1], Reading = attributes[1], Meaning = attributes[2], Selected = true, JLPT_Level = jlpt_level });
                        }
                        else
                        {
                            result.Add(new ScrapedKanji { Word = attributes[0], Reading = attributes[1], Meaning = attributes[2], Selected= true, JLPT_Level = jlpt_level });
                        }

                    }

                }
            }
            return result;
        }

    }

   
}
