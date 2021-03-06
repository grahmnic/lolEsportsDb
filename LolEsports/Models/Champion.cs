﻿using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Champion
    {
        public Champion()
        {
            Account = new HashSet<Account>();
            FavoriteChampionRef = new HashSet<FavoriteChampionRef>();
            PlayerMatchRefChampionBanned = new HashSet<PlayerMatchRef>();
            PlayerMatchRefChampionPlayed = new HashSet<PlayerMatchRef>();
        }

        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public string ChampionImage { get; set; }

        public ICollection<Account> Account { get; set; }
        public ICollection<FavoriteChampionRef> FavoriteChampionRef { get; set; }
        public ICollection<PlayerMatchRef> PlayerMatchRefChampionBanned { get; set; }
        public ICollection<PlayerMatchRef> PlayerMatchRefChampionPlayed { get; set; }
    }
}
