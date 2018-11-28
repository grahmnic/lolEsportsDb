using LolEsports.DataStructures;
using LolEsports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolEsports.DataAccess
{
    public class TournamentTransaction
    {
        public TournamentStructure GetTournament(int id)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        TournamentStructure tourney = new TournamentStructure();
                        Tournament t = context.Tournament.Where(i => i.TournamentId == id).FirstOrDefault();
                        if (t == null)
                        {
                            tourney.error = 1;
                            tourney.message = "Tournament does not exist in the database.";
                            return tourney;
                        }
                        tourney.TournamentName = t.TournamentName;
                        tourney.StartDate = t.StartDate;
                        tourney.EndDate = t.EndDate;
                        tourney.Season = t.Season;
                        PlayerTransaction p = new PlayerTransaction();
                        tourney.MVP = p.GetPlayer(t.Mvpid);
                        Coach c = context.Coach.Where(i => i.CoachId == t.Mvcid).FirstOrDefault();
                        tourney.MVCName = context.Person.Where(i => i.PersonId == c.PersonId).Select(x => x.PersonName).FirstOrDefault();
                        tourney.MVCIgn = c.CoachIgn;
                        MatchTransaction mt = new MatchTransaction();
                        tourney.TournamentBanner = t.TournamentBanner;
                        context.Match.Where(i => (!i.IsFinals).GetValueOrDefault() && (!i.IsQuarters).GetValueOrDefault() && (!i.IsSemis).GetValueOrDefault() && i.TournamentId == t.TournamentId).OrderBy(o => o.DatePlayed).Select(x => x.MatchId)
                            .ToList().ForEach((match) =>
                            {
                                tourney.Matches.Add(mt.GetMatch(match));
                            });
                        context.Match.Where(i => (i.IsFinals).GetValueOrDefault() && (i.IsQuarters).GetValueOrDefault() && (i.IsSemis).GetValueOrDefault() && i.TournamentId == t.TournamentId).OrderBy(o => o.DatePlayed).Select(x => x.MatchId)
                            .ToList().ForEach((match) =>
                            {
                                tourney.Playsoffs.Add(mt.GetMatch(match));
                            });

                        dbContextTransaction.Commit();
                        return tourney;
                    }
                    catch (Exception e)
                    {
                        TournamentStructure tourney = new TournamentStructure();
                        tourney.error = 1;
                        tourney.message = e.ToString();
                        dbContextTransaction.Rollback();
                        return tourney;
                    }
                }
            }
        }
    }
}
