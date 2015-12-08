using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiListCreator.Data
{
    public class KanjiSortedList
    {
        public int MaxRows { get; set; }

        private List<KanjiListRow> _myRows;
        public List<KanjiListRow> MyContent
        {
            get{ return _myRows; } 
        }

        public KanjiSortedList()
        {
            _myRows = new List<KanjiListRow>();
        }


        
    }
}
