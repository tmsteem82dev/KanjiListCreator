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
    }
}
