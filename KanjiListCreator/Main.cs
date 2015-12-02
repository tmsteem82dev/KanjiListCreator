using KanjiListCreator.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanjiListCreator
{
    public partial class Main : Form
    {

        List<ScrapedKanji> myKanjiList;

        private const string JLPT5 = "http://www.tanos.co.uk/jlpt/jlpt5/vocab/";
        private const string JLPT4 = "http://www.tanos.co.uk/jlpt/jlpt4/vocab/";

        public Main()
        {
            InitializeComponent();

            lvwData.Columns.Add("Kanji");
            lvwData.Columns.Add("Reading");
            lvwData.Columns.Add("Meaning");

        }

        private void btnData_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create(@"http://jisho.org/api/v1/search/words?keyword=%23jlpt-n5 page=2");
            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string json = reader.ReadToEnd();

            JObject searchResult = JObject.Parse(json);

            IList<JToken> results = searchResult["data"].Children().ToList();

            //List<Kanji> kanList = searchResult["data"].Serial
            int limiter = 0;

            if(File.Exists("test.txt"))
            {
                File.Delete("test.txt");
            }

            foreach(JToken result in results)
            {
                Kanji testkan = JsonConvert.DeserializeObject<Kanji>(result.ToString());

                using (StreamWriter w = File.AppendText("test.txt"))
                {
                    w.WriteLine(String.Format("{0}, {1}",testkan.My_Japanese[0].Word, testkan.My_Japanese[0].Reading));
                }

                    limiter++;

                if(limiter > 100)
                {
                    break;
                }
            }

            //foreach( JObject content in searchResult["data"].Children<JObject>())
            //{               
            //    foreach(JProperty prop in content.Properties())
            //    {
            //        switch( prop.Name)
            //        {
            //            case "japanese":
            //                if(prop.HasValues)
            //                {
            //                    JToken value = prop.Value;
            //                    string tests = value[0].ToString();
            //                    JEnumerable<JToken> objs = prop.Children<JToken>();
            //                    foreach(JToken testy in objs)
            //                    {

            //                    }

                               
            //                }
            //                break;
            //            default:
            //                break;
            //        }

            //    }
            //}

            //IList<Kanji> kanjiList = new List<Kanji>();
            //foreach(JToken result in results)
            //{
            //    IList<JToken> kanjiDataList = result.ToList();
            //    foreach(JToken kanjiData in kanjiDataList)
            //    {
            //        //JObject test = kanjiData.ToObject<JObject>();
            //        IList<string> list = kanjiData.Values<string>().ToList<string>();

            //        //string name = kanjiData["Name"].ToString();
            //        //switch (kanjiData.Name)
            //        //{
            //        //    default:
            //        //        break;
            //        //}
            //    }


                //Kanji myKanji = JsonConvert.DeserializeObject<Kanji>(result.ToString());
               // kanjiList.Add(myKanji);
           // }

        }

        private void btnScrape_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://www.tanos.co.uk/jlpt/jlpt5/vocab/");

            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string htmlBody = reader.ReadToEnd();

           myKanjiList =  new List<ScrapedKanji>();

            string[] grabTable = htmlBody.Split(new string[] { "<th>Kanji</th>" }, StringSplitOptions.RemoveEmptyEntries);
            string[] splitRows = grabTable[1].Split(new string[] { "<tr><td>" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string row in splitRows)
            {
                List<string> attributes = new List<string>();
                if(row.Substring(0,5).Equals("</td>"))
                {
                    attributes.Add("");
                }

                if (row.Contains("<td>"))
                {
                    string[] splitColumns = row.Split(new string[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);

                    
                    foreach(string splitColumn in splitColumns)
                    {
                        string column = splitColumn;
                        string value = "";
                        int tag = 0;
                        if(column.Contains("<td>"))
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

                    if(attributes.Count > 0)
                    {
                        if(attributes[0].Equals(""))
                        {
                            myKanjiList.Add(new ScrapedKanji { Word = attributes[1], Reading = attributes[1], Meaning= attributes[2] });
                        }
                        else
                        {
                            myKanjiList.Add(new ScrapedKanji { Word = attributes[0], Reading = attributes[1], Meaning = attributes[2] });
                        }

                    }

                }
            }

            KanjiListToListView(myKanjiList);
            
        }

        private void KanjiListToListView(List<ScrapedKanji> kanjiList)
        {
            lvwData.Items.Clear();

            foreach (ScrapedKanji scrappy in kanjiList)
            {
                ListViewItem itm = lvwData.Items.Add(scrappy.Word);
                itm.Checked = true;
                itm.SubItems.Add(scrappy.Reading);
                itm.SubItems.Add(scrappy.Meaning);
            }

            lvwData.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwData.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwData.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveKanjiDialog.Filter = "Text file|*.txt";
            saveKanjiDialog.Title = "Save kanji you want to learn";
            DialogResult res= saveKanjiDialog.ShowDialog();

            if (res != DialogResult.Cancel && saveKanjiDialog.FileName != "")
            {
                if(File.Exists(saveKanjiDialog.FileName))
                {
                    File.Delete(saveKanjiDialog.FileName);

                }

                foreach (ListViewItem itm in lvwData.Items)
                {
                    if (itm.Checked)
                    {
                        ScrapedKanji kanji = myKanjiList[itm.Index];
                        using (StreamWriter w = File.AppendText(saveKanjiDialog.FileName))
                        {
                            w.WriteLine(String.Format("{0},{1},{2}", kanji.Word, kanji.Reading, kanji.Meaning));
                        }
                    }
                }
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openKanjiDialog.Filter = "Text file|*.txt";
            openKanjiDialog.Title = "Load kanji you want to learn";
            DialogResult res = openKanjiDialog.ShowDialog();

            if (res != DialogResult.Cancel && openKanjiDialog.FileName != "")
            {
                myKanjiList = new List<ScrapedKanji>();
                using (StreamReader r = new StreamReader(openKanjiDialog.FileName))
                {
                    while(true)
                    {
                        string line = r.ReadLine();
                        if(line == null)
                        {
                            break;
                        }

                        string[] splitLine = line.Split(',');
                        myKanjiList.Add(new ScrapedKanji { Word = splitLine[0], Reading = splitLine[1], Meaning = splitLine[2] });

                    }
                }
            }

            if(myKanjiList.Count > 0)
            {
                KanjiListToListView(myKanjiList);
            }
        }
    }
}
