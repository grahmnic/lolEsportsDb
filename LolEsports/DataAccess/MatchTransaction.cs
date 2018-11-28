using LolEsports.DataStructures;
using LolEsports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolEsports.DataAccess
{
    public class MatchTransaction
    {
        public MatchStructure GetMatch(int id)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        MatchStructure match = new MatchStructure();
                        Match m = context.Match.Where(i => i.MatchId == id).FirstOrDefault();
                        if(m == null)
                        {
                            match.error = 1;
                            match.message = "Match does not exist in the database.";
                            return match;
                        }

                        match.DatePlayed = m.DatePlayed;
                        match.MatchLocation = m.MatchLocation;
                        match.Duration = m.Duration;

                        Team wt = context.Team.Where(i => i.TeamId == m.WinningTeamId).FirstOrDefault();
                        TeamTransaction tt = new TeamTransaction();
                        match.WinningTeam = tt.GetTeam(wt.TeamId);
                        Team lt = context.Team.Where(i => i.TeamId == m.LosingTeamId).FirstOrDefault();
                        match.LosingTeam = tt.GetTeam(lt.TeamId);

                        match.WinningTeamStats = context.PlayerMatchRef.Where(i => i.MatchId == m.MatchId && match.WinningTeam.ids.Contains(i.PlayerId)).OrderBy(o => o.PlayerId).ToList();
                        match.LosingTeamStats = context.PlayerMatchRef.Where(i => i.MatchId == m.MatchId && match.LosingTeam.ids.Contains(i.PlayerId)).OrderBy(o => o.PlayerId).ToList();

                        match.PlayerNames = new List<String>();
                        match.ChampionImages = new List<String>();
                        match.ChampionBans = new List<String>();
                        match.WinningTeamStats.ForEach((player) =>
                        {
                            match.PlayerNames.Add(context.Player.Where(x => player.PlayerId == x.PlayerId).Select(l => l.PlayerIgn).FirstOrDefault());
                            match.ChampionImages.Add(context.Champion.Where(x => player.ChampionPlayedId == x.ChampionId).Select(l => l.ChampionImage).FirstOrDefault());
                            match.ChampionBans.Add(context.Champion.Where(x => player.ChampionBannedId == x.ChampionId).Select(l => l.ChampionImage).FirstOrDefault());
                        });

                        match.PlayerNames2 = new List<String>();
                        match.ChampionImages2 = new List<String>();
                        match.ChampionBans2 = new List<String>();
                        match.LosingTeamStats.ForEach((player) =>
                        {
                            match.PlayerNames2.Add(context.Player.Where(x => player.PlayerId == x.PlayerId).Select(l => l.PlayerIgn).FirstOrDefault());
                            match.ChampionImages2.Add(context.Champion.Where(x => player.ChampionPlayedId == x.ChampionId).Select(l => l.ChampionImage).FirstOrDefault());
                            match.ChampionBans2.Add(context.Champion.Where(x => player.ChampionBannedId == x.ChampionId).Select(l => l.ChampionImage).FirstOrDefault());
                        });

                        Tournament t = context.Tournament.Where(x => x.TournamentId == m.TournamentId).FirstOrDefault();
                        match.TournamentID = t.TournamentId;
                        match.TournamentName = t.TournamentName;

                        dbContextTransaction.Commit();
                        return match;
                    }
                    catch (Exception e)
                    {
                        MatchStructure match = new MatchStructure();
                        match.error = 1;
                        match.message = e.ToString();
                        dbContextTransaction.Rollback();
                        return match;
                    }
                }
            }
        }
    }
}
