using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Player
    {
        public Player()
        {
            CompetitorTeamRef = new HashSet<CompetitorTeamRef>();
            FavoritePlayerRef = new HashSet<FavoritePlayerRef>();
            Match = new HashSet<Match>();
            PlayerMatchRef = new HashSet<PlayerMatchRef>();
            Tournament = new HashSet<Tournament>();
        }

        public int PlayerId { get; set; }
        public int PersonId { get; set; }
        public string PlayerIgn { get; set; }
        public string PlayerRole { get; set; }
        public int TotalScore { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalAssists { get; set; }
        public string Quote { get; set; }

        public Person Person { get; set; }
        public ICollection<CompetitorTeamRef> CompetitorTeamRef { get; set; }
        public ICollection<FavoritePlayerRef> FavoritePlayerRef { get; set; }
        public ICollection<Match> Match { get; set; }
        public ICollection<PlayerMatchRef> PlayerMatchRef { get; set; }
        public ICollection<Tournament> Tournament { get; set; }
    }
}
