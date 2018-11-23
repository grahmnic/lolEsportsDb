using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class FavoritePlayerRef
    {
        public int FavoritePlayerRefId { get; set; }
        public int? UserId { get; set; }
        public int? PlayerId { get; set; }

        public Player Player { get; set; }
        public Account User { get; set; }
    }
}
