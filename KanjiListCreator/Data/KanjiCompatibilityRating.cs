﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiListCreator.Data
{
    public class KanjiCompatibilityRating
    {
        public int Score { get; set; }
        public ScrapedKanji MyKanji { get; set; }
    }
}
