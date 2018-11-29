using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Media
    {
        public int MediaId { get; set; }
        public string Link { get; set; }
        public string Thumbnail { get; set; }
        public string FirstTag { get; set; }
        public string SecondTag { get; set; }
        public string ThirdTag { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
