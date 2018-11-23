using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            FavoriteTournamentRef = new HashSet<FavoriteTournamentRef>();
            Match = new HashSet<Match>();
            TournamentRegionRef = new HashSet<TournamentRegionRef>();
        }

        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public decimal PrizePool { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Season { get; set; }
        public int Mvpid { get; set; }
        public int Mvcid { get; set; }

        public Coach Mvc { get; set; }
        public Player Mvp { get; set; }
        public ICollection<FavoriteTournamentRef> FavoriteTournamentRef { get; set; }
        public ICollection<Match> Match { get; set; }
        public ICollection<TournamentRegionRef> TournamentRegionRef { get; set; }
    }
}
