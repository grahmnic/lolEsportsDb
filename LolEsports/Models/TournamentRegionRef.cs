using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class TournamentRegionRef
    {
        public int TournamentRegionRefId { get; set; }
        public int TournamentId { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
        public Tournament Tournament { get; set; }
    }
}
