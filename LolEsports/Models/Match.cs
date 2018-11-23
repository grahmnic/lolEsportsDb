using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Match
    {
        public Match()
        {
            PlayerMatchRef = new HashSet<PlayerMatchRef>();
        }

        public int MatchId { get; set; }
        public int TournamentId { get; set; }
        public DateTime DatePlayed { get; set; }
        public string MatchLocation { get; set; }
        public int Duration { get; set; }
        public bool? IsSemis { get; set; }
        public bool? IsQuarters { get; set; }
        public bool? IsFinals { get; set; }
        public int WinningTeamId { get; set; }
        public int LosingTeamId { get; set; }
        public int PlayerOfTheGameId { get; set; }

        public Team LosingTeam { get; set; }
        public Player PlayerOfTheGame { get; set; }
        public Tournament Tournament { get; set; }
        public Team WinningTeam { get; set; }
        public ICollection<PlayerMatchRef> PlayerMatchRef { get; set; }
    }
}
