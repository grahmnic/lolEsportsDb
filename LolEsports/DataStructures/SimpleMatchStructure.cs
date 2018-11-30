using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolEsports.DataStructures
{
    public class SimpleMatchStructure
    {
        public int MatchId;
        public DateTime DatePlayed;
        public TeamStructure WinningTeam;
        public TeamStructure LosingTeam;
    }
}
