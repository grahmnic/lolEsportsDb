using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class CompetitorTeamRef
    {
        public int CompetitorTeamRefId { get; set; }
        public int PlayerId { get; set; }
        public int CoachId { get; set; }
        public int TeamId { get; set; }
        public int Season { get; set; }

        public Coach Coach { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}
