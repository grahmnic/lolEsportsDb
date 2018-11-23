using System;
using System.Collections.Generic;

namespace LolEsports.Models
{
    public partial class Coach
    {
        public Coach()
        {
            CompetitorTeamRef = new HashSet<CompetitorTeamRef>();
            Tournament = new HashSet<Tournament>();
        }

        public int CoachId { get; set; }
        public int PersonId { get; set; }
        public string CoachIgn { get; set; }

        public Person Person { get; set; }
        public ICollection<CompetitorTeamRef> CompetitorTeamRef { get; set; }
        public ICollection<Tournament> Tournament { get; set; }
    }
}
