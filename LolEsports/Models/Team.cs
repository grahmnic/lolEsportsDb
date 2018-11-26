using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Team
    {
        public Team()
        {
            CompetitorTeamRef = new HashSet<CompetitorTeamRef>();
            FavoriteTeamRef = new HashSet<FavoriteTeamRef>();
            MatchLosingTeam = new HashSet<Match>();
            MatchWinningTeam = new HashSet<Match>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int RegionId { get; set; }
        public string TeamLogo { get; set; }
        public string TeamPicture { get; set; }

        public Region Region { get; set; }
        public ICollection<CompetitorTeamRef> CompetitorTeamRef { get; set; }
        public ICollection<FavoriteTeamRef> FavoriteTeamRef { get; set; }
        public ICollection<Match> MatchLosingTeam { get; set; }
        public ICollection<Match> MatchWinningTeam { get; set; }
    }
}
