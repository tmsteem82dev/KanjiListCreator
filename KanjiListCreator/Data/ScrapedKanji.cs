using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiListCreator.Data
{
    public class ScrapedKanji
    {
        public string Word { get; set; }
        public string Reading { get; set; }
        public string Meaning { get; set; }

        public bool Selected { get; set; }
        public string JLPT_Level { get; set; }

    }
}
