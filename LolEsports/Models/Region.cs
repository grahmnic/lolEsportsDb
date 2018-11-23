using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Region
    {
        public Region()
        {
            FavoriteRegionRef = new HashSet<FavoriteRegionRef>();
            Team = new HashSet<Team>();
            TournamentRegionRef = new HashSet<TournamentRegionRef>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public ICollection<FavoriteRegionRef> FavoriteRegionRef { get; set; }
        public ICollection<Team> Team { get; set; }
        public ICollection<TournamentRegionRef> TournamentRegionRef { get; set; }
    }
}
