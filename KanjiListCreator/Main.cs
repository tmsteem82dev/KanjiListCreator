using KanjiListCreator.Data;
using KanjiListCreator.Scraping;
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
        private const string JLPT3 = "http://www.tanos.co.uk/jlpt/jlpt3/vocab/";
        private const string JLPT2 = "http://www.tanos.co.uk/jlpt/jlpt2/vocab/";
        private const string JLPT1 = "http://www.tanos.co.uk/jlpt/jlpt1/vocab/";

        public Main()
        {
            InitializeComponent();

            lvwData.Columns.Add("Kanji");
            lvwData.Columns.Add("Reading");
            lvwData.Columns.Add("Meaning");
            lvwData.Columns.Add("JLPT Level");


        }

        private void btnData_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create(@"http://jisho.org/api/v1/search/words?keyword=%23jlpt-n5 page=2");
            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string json = reader.ReadToEnd();

            JObject searchResult = JObject.Parse(json);

            IList<JToken> results = searchResult["data"].Children().ToList();
                        

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
            
            Scraper myScraper = new Scraper();

            string htmlBody = myScraper.GetHtmlFromUrl(JLPT5);

            myKanjiList = myScraper.GetKanjiFromPage(htmlBody, "jlpt5");


            

            //KanjiListToListView(myKanjiList);
            
        }

        private void AddKanjiToListView(List<ScrapedKanji> kanjiList, ListView listy)
        {
            foreach (ScrapedKanji scrappy in kanjiList)
            {
                ListViewItem itm = listy.Items.Add(scrappy.Word);
                
                itm.SubItems.Add(scrappy.Reading);
                itm.SubItems.Add(scrappy.Meaning);
                itm.SubItems.Add(scrappy.JLPT_Level);
                itm.Checked = scrappy.Selected;
                itm.Tag = scrappy;
                if (itm.Checked)
                {                    
                    itm.BackColor = Color.Green;
                }
                else
                {
                    itm.BackColor = Color.Red;
                }
            }
        }

        private void KanjiListToListView(List<ScrapedKanji> kanjiList)
        {
            lvwData.Items.Clear();

            AddKanjiToListView(kanjiList, lvwData);

            lvwData.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwData.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwData.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void SaveKanjiToDisk(List<ScrapedKanji> kanjiList, string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);

            }

            foreach (ScrapedKanji kanji in kanjiList)
            {
                using (StreamWriter w = File.AppendText(filename))
                {
                    w.WriteLine(String.Format("{0},{1},{2}", kanji.Word, kanji.Reading, kanji.Meaning));
                }
            }
        }

        private void SaveKanjiJsonToDisk(List<ScrapedKanji> kanjiList, string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);

            }

            var json = JsonConvert.SerializeObject(kanjiList);

            File.AppendAllText(filename, json);
        }



           

        private void btnProcessAll_Click(object sender, EventArgs e)
        {
            Scraper myScraper = new Scraper();
            List<ScrapedKanji> kanjiList = new List<ScrapedKanji>();
            string htmlBody = "";

            folderKanjiDialog.ShowNewFolderButton = true;
            if (folderKanjiDialog.ShowDialog() != DialogResult.Cancel)
            {
                string path = folderKanjiDialog.SelectedPath;
                htmlBody = myScraper.GetHtmlFromUrl(JLPT5);
                kanjiList = myScraper.GetKanjiFromPage(htmlBody, "jlpt5");
                SaveKanjiJsonToDisk(kanjiList, path + "\\jlpt5.json");

                htmlBody = myScraper.GetHtmlFromUrl(JLPT4);
                kanjiList = myScraper.GetKanjiFromPage(htmlBody, "jlpt4");
                SaveKanjiJsonToDisk(kanjiList, path + "\\jlpt4.json");

                htmlBody = myScraper.GetHtmlFromUrl(JLPT3);
                kanjiList = myScraper.GetKanjiFromPage(htmlBody, "jlpt3");
                SaveKanjiJsonToDisk(kanjiList, path + "\\jlpt3.json");

                htmlBody = myScraper.GetHtmlFromUrl(JLPT2);
                kanjiList = myScraper.GetKanjiFromPage(htmlBody, "jlpt2");
                SaveKanjiJsonToDisk(kanjiList, path + "\\jlpt2.json");

                htmlBody = myScraper.GetHtmlFromUrl(JLPT1);
                kanjiList = myScraper.GetKanjiFromPage(htmlBody, "jlpt1");
                SaveKanjiJsonToDisk(kanjiList, path + "\\jlpt1.json");
            }

        }

        private void btnLoadFromJson_Click(object sender, EventArgs e)
        {
            openKanjiDialog.Filter = "Text file|*.json";
            openKanjiDialog.Title = "Load kanji you want to learn";
            DialogResult res = openKanjiDialog.ShowDialog();
            
            if (res != DialogResult.Cancel && openKanjiDialog.FileName != "")
            {
                StreamReader r = new StreamReader(openKanjiDialog.FileName);

                string json = r.ReadToEnd();

                List<ScrapedKanji> kanjiList = JArray.Parse(json).ToObject<List<ScrapedKanji>>();
                if (kanjiList.Count > 0)
                {
                    lblKanjiCount.Text = String.Format("Kanji count: {0}", kanjiList.Count);
                    lvwData.Items.Clear();
                    AddKanjiToListView(kanjiList, lvwData);
                    int selectedItemCount = 0;
                    foreach(ListViewItem itm in lvwData.Items)
                    {
                        if(itm.Checked)
                        {
                            selectedItemCount++;
                        }
                    }

                    lblSelectedKanjiCount.Text = String.Format("Selected kanji count: {0}", selectedItemCount);

                    lvwData.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvwData.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvwData.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvwData.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                    lvwData.Focus();
                }

                r.Close();
            }
        }

        private void lvwData_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if(e.Item.Checked)
            {
                e.Item.BackColor = Color.Green;
            }
            else
            {
                e.Item.BackColor = Color.Red;
            }
        }

        private void btnAddFromJson_Click(object sender, EventArgs e)
        {
            openKanjiDialog.Filter = "Json file|*.json";
            openKanjiDialog.Title = "Load kanji you want to learn";
            DialogResult res = openKanjiDialog.ShowDialog();

            if (res != DialogResult.Cancel && openKanjiDialog.FileName != "")
            {
                StreamReader r = new StreamReader(openKanjiDialog.FileName);

                string json = r.ReadToEnd();

                List<ScrapedKanji> kanjiList = JArray.Parse(json).ToObject<List<ScrapedKanji>>();
                if (kanjiList.Count > 0)
                {   
                    AddKanjiToListView(kanjiList, lvwData);
                    lblKanjiCount.Text = String.Format("Kanji count {0}", lvwData.Items.Count);
                    lvwData.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvwData.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvwData.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvwData.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        private void btnSaveToJson_Click(object sender, EventArgs e)
        {
            List<ScrapedKanji> kanjiScrapes = new List<ScrapedKanji>();
            foreach(ListViewItem itm in lvwData.Items)
            {
                ScrapedKanji kanji = new ScrapedKanji();

                kanji = (ScrapedKanji)itm.Tag;
                kanji.Selected = itm.Checked;

                kanjiScrapes.Add(kanji);
            }

            if(kanjiScrapes.Count > 0)
            {
                saveKanjiDialog.Filter = "Json file|*.json";
                saveKanjiDialog.Title = "Save data to Json file";

                DialogResult res = saveKanjiDialog.ShowDialog();
                string filename = saveKanjiDialog.FileName;
                if(res != DialogResult.Cancel && res != DialogResult.Abort && filename != "")
                {
                    SaveKanjiJsonToDisk(kanjiScrapes, filename);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvwData.Items.Clear();
        }

        private void btnTrySort_Click(object sender, EventArgs e)
        {
            folderKanjiDialog.ShowNewFolderButton = true;
            DialogResult dr = folderKanjiDialog.ShowDialog();

            if(dr == DialogResult.Abort || dr == DialogResult.Cancel)
            {
                return;
            }

            string path;
            if((path = folderKanjiDialog.SelectedPath) == "")
            {
                return;
            }

            List<ScrapedKanji> availableKanjiList = new List<ScrapedKanji>();
            KanjiSortedList kanjiEndList = new KanjiSortedList();



            foreach(ListViewItem itm in lvwData.Items)
            {
                if(itm.Tag != null)
                {
                    ScrapedKanji kanji = (ScrapedKanji)itm.Tag;
                    if (kanji.Selected)
                    {
                        availableKanjiList.Add(kanji);
                    }
                }
            }

            int count = 0;

            KanjiListRow kanjiRow = new KanjiListRow();
            kanjiRow.MaxColumnCount = 6;
            string validateHiragana = "あいうえおかきくけこさしすせそはひふへほたちつてとらりるれろやゆまみむめもなにぬねのじがぎぐげごばびぶべぼだぢづでど";

            do
            {
                ScrapedKanji firstSibling = availableKanjiList[0];
                bool firstIsKanji = true;

                if(validateHiragana.Contains(firstSibling.Word[0]))
                {
                    firstIsKanji = false;
                }            

                //availableKanjiList.Remove(firstSibling);
                availableKanjiList.RemoveAll(removeKanji => removeKanji.Word.Equals(firstSibling.Word, StringComparison.InvariantCultureIgnoreCase));
                List<KanjiCompatibilityRating> ratedKanji = new List<KanjiCompatibilityRating>();

                foreach(ScrapedKanji kanjiCandidate in availableKanjiList)
                {
                    int candidateScore = 0;

                    if(kanjiCandidate.Word.Contains(firstSibling.Word))
                    {
                        candidateScore += 10;
                    }

                    if(kanjiCandidate.Word.Contains(firstSibling.Word[0]))
                    {

                        if (firstIsKanji)
                        {
                            candidateScore += 10;
                        }

                        if(kanjiCandidate.Word[0] == firstSibling.Word[0])
                        {
                            candidateScore += 10;
                        }

                        if (!firstIsKanji)
                        {
                            if (kanjiCandidate.Word[0] != firstSibling.Word[0])
                            {
                                candidateScore = 0;
                            }
                        }

                        if (candidateScore != 0)
                        {
                            foreach (char moji in firstSibling.Word)
                            {
                                if (kanjiCandidate.Word.Contains(moji))
                                {
                                    candidateScore++;
                                }
                            }
                        }
                    }
                    
                    ratedKanji.Add(new KanjiCompatibilityRating { Score = candidateScore, MyKanji = kanjiCandidate });
                }


                ratedKanji = ratedKanji.OrderByDescending(mykanji => mykanji.Score).ToList<KanjiCompatibilityRating>();


                kanjiRow = AddToListRow(firstSibling, kanjiRow, kanjiEndList);

                //foreach (KanjiCompatibilityRating rk in ratedKanji)
                
                while(ratedKanji.Count > 0)
                {
                    KanjiCompatibilityRating rk = ratedKanji[0];

                    if (rk.MyKanji.Word.Equals("素早い", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Found!");
                    }

                    if (rk.Score ==0)
                    {
                        break;
                    }

                    kanjiRow = AddToListRow(rk.MyKanji, kanjiRow, kanjiEndList);
                    //availableKanjiList.Remo availableKanjiList.Where(rvk => rvk.Word.Equals(rk.MyKanji.Word)).ToList();
                    //availableKanjiList.Remove(rk.MyKanji);
                    ratedKanji.RemoveAll(removeKanji => removeKanji.MyKanji.Word.Equals(rk.MyKanji.Word, StringComparison.InvariantCultureIgnoreCase));
                    availableKanjiList.RemoveAll(removeKanji => removeKanji.Word.Equals(rk.MyKanji.Word, StringComparison.InvariantCultureIgnoreCase));
                }

                //if(kanjiEndList.MyContent.Count > 30)
                //{
                //    WriteSortedListToCSV(kanjiEndList, path);
                //    break;
                //}
                

            }
            while (availableKanjiList.Count > 0);

            WriteSortedListToCSV(kanjiEndList, path);
        }

        private void WriteSortedListToCSV(KanjiSortedList kanjiSortedList, string path)
        {
            using (StreamWriter sw = new StreamWriter(String.Format("{0}\\myfirstkanji.csv", path),false,Encoding.Unicode))
            {
                foreach (KanjiListRow row in kanjiSortedList.MyContent)
                {
                    string line="";
                    foreach(ScrapedKanji kanji in row.GetColumns())
                    {
                        line += kanji.Word + ",";
                    }

                    line = line.Substring(0, line.Length - 1);
                    sw.WriteLine(line);
                }
            }
        }

        private KanjiListRow AddToListRow(ScrapedKanji kanji, KanjiListRow currentRow, KanjiSortedList kanjiEndList)
        {
            KanjiListRow currCopy = currentRow;
            if (!currCopy.AddKanjiToRow(kanji))
            {
                kanjiEndList.MyContent.Add(currCopy);
                currCopy = new KanjiListRow();
                currCopy.MaxColumnCount = 6;
                currCopy.AddKanjiToRow(kanji);
            }

            return currCopy;
        }
    }
}
