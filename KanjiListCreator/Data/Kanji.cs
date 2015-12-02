using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiListCreator.Data
{
    public class Kanji
    {
        public bool Is_common { get; set; }

        [JsonProperty(PropertyName = "japanese")]
        public List<Japanese> My_Japanese { get; set; }

        [JsonProperty(PropertyName = "senses")]
        public List<Senses> The_Senses { get; set; }
    }
}
