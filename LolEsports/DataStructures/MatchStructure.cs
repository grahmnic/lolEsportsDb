using LolEsports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolEsports.DataStructures
{
    public class MatchStructure
    {
        public int error;
        public String message;

        public int TournamentID;
        public String TournamentName;
        public DateTime DatePlayed;
        public String MatchLocation;
        public int Duration;
        public TeamStructure WinningTeam;
        public TeamStructure LosingTeam;
        public List<PlayerMatchRef> WinningTeamStats;
        public List<PlayerMatchRef> LosingTeamStats;
        public List<String> PlayerNames;
        public List<String> ChampionImages;
        public List<String> ChampionBans;
        public List<String> PlayerNames2;
        public List<String> ChampionImages2;
        public List<String> ChampionBans2;
    }
}
