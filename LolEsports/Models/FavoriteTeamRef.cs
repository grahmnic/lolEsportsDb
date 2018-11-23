using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class FavoriteTeamRef
    {
        public int FavoriteTeamRefId { get; set; }
        public int? UserId { get; set; }
        public int? TeamId { get; set; }

        public Team Team { get; set; }
        public Account User { get; set; }
    }
}
