using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Account
    {
        public Account()
        {
            FavoriteChampionRef = new HashSet<FavoriteChampionRef>();
            FavoritePlayerRef = new HashSet<FavoritePlayerRef>();
            FavoriteRegionRef = new HashSet<FavoriteRegionRef>();
            FavoriteTeamRef = new HashSet<FavoriteTeamRef>();
            FavoriteTournamentRef = new HashSet<FavoriteTournamentRef>();
        }

        public int UserId { get; set; }
        public int LevelAccess { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<FavoriteChampionRef> FavoriteChampionRef { get; set; }
        public ICollection<FavoritePlayerRef> FavoritePlayerRef { get; set; }
        public ICollection<FavoriteRegionRef> FavoriteRegionRef { get; set; }
        public ICollection<FavoriteTeamRef> FavoriteTeamRef { get; set; }
        public ICollection<FavoriteTournamentRef> FavoriteTournamentRef { get; set; }
    }
}
