using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class FavoriteTournamentRef
    {
        public int FavoriteTournamentRefId { get; set; }
        public int? UserId { get; set; }
        public int? ChampionId { get; set; }

        public Tournament Champion { get; set; }
        public Account User { get; set; }
    }
}
