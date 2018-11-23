using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class PlayerMatchRef
    {
        public int PlayerMatchRefId { get; set; }
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public int ChampionPlayedId { get; set; }
        public int PlayerKills { get; set; }
        public int PlayerDeaths { get; set; }
        public int PlayerAssists { get; set; }
        public int PlayerScore { get; set; }
        public int TowersTaken { get; set; }
        public int BaronsTaken { get; set; }
        public int DragonsTaken { get; set; }
        public int ChampionBannedId { get; set; }

        public Champion ChampionBanned { get; set; }
        public Champion ChampionPlayed { get; set; }
        public Match Match { get; set; }
        public Player Player { get; set; }
    }
}
