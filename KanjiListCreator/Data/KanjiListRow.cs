using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiListCreator.Data
{
    public class KanjiListRow
    {
        public int MaxColumnCount { get; set; }

        private List<ScrapedKanji> _myColumns;

        public bool AddKanjiToRow(ScrapedKanji kanji)
        {
            bool result = true;

            //check if kanji is already in the list
            if(_myColumns == null)
            {
                _myColumns = new List<ScrapedKanji>();
            }

            //columns may not exceed the maximum number
            if(MaxColumnCount == _myColumns.Count)
            {
                return false;
            }

            foreach(ScrapedKanji listKanji in _myColumns)
            {
                if(listKanji.Word.Equals(kanji.Word,StringComparison.InvariantCultureIgnoreCase))
                {                    
                    result = false;
                    break;
                }
            }

            if(result)
            {
                _myColumns.Add(kanji);
            }
            
            return result;
        }

        public IEnumerable<ScrapedKanji> GetColumns()
        {
            return _myColumns;
        }

    }
}
