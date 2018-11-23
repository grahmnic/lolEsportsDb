using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class FavoriteChampionRef
    {
        public int FavoriteChampionRefId { get; set; }
        public int UserId { get; set; }
        public int? ChampionId { get; set; }

        public Champion Champion { get; set; }
        public Account User { get; set; }
    }
}
