using LolEsports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolEsports.DataStructures
{
    public class TournamentStructure
    {
        public int error;
        public String message;

        public String TournamentName;
        public DateTime StartDate;
        public DateTime EndDate;
        public int Season;
        public PlayerStructure MVP;
        public String MVCName;
        public String MVCIgn;
        public String TournamentBanner;
        public List<SimpleMatchStructure> Matches;
        public List<SimpleMatchStructure> Playsoffs;
        public List<StandingsStructure> Standings;
    }
}
