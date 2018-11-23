using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class FavoriteRegionRef
    {
        public int FavoriteRegionRefId { get; set; }
        public int? UserId { get; set; }
        public int? RegionId { get; set; }

        public Region Region { get; set; }
        public Account User { get; set; }
    }
}
