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
                        TeamTransaction tt = new TeamTransaction();
                        tourney.TournamentBanner = t.TournamentBanner;
                        tourney.Matches = new List<SimpleMatchStructure>();
                        tourney.Standings = new List<StandingsStructure>();
                        context.Team.ToList().ForEach((team) =>
                        {
                            StandingsStructure s = new StandingsStructure();
                            s.TeamName = team.TeamName;
                            s.TeamLogo = team.TeamPicture;
                            tourney.Standings.Add(s);
                        });
                        context.Match.Where(i => (!i.IsFinals).GetValueOrDefault() && (!i.IsQuarters).GetValueOrDefault() && (!i.IsSemis).GetValueOrDefault() && i.TournamentId == t.TournamentId).OrderBy(o => o.DatePlayed)
                            .ToList().ForEach((match) =>
                            {
                                SimpleMatchStructure sms = new SimpleMatchStructure();
                                sms.MatchId = match.MatchId;
                                sms.DatePlayed = match.DatePlayed;
                                sms.WinningTeam = tt.GetTeam(match.WinningTeamId);
                                sms.LosingTeam = tt.GetTeam(match.LosingTeamId);
                                tourney.Matches.Add(sms);
                                tourney.Standings.Find(l => l.TeamName == sms.WinningTeam.TeamName).Wins++;
                                tourney.Standings.Find(l => l.TeamName == sms.LosingTeam.TeamName).Losses++;
                            });
                        tourney.Playsoffs = new List<SimpleMatchStructure>();
                        context.Match.Where(i => ((i.IsFinals).GetValueOrDefault() == true || (i.IsQuarters).GetValueOrDefault() == true || (i.IsSemis).GetValueOrDefault() == true) && i.TournamentId == t.TournamentId).OrderBy(o => o.DatePlayed)
                            .ToList().ForEach((match) =>
                            {
                                SimpleMatchStructure sms = new SimpleMatchStructure();
                                sms.MatchId = match.MatchId;
                                sms.DatePlayed = match.DatePlayed;
                                sms.WinningTeam = tt.GetTeam(match.WinningTeamId);
                                sms.LosingTeam = tt.GetTeam(match.LosingTeamId);
                                tourney.Playsoffs.Add(sms);
                            });
                        tourney.Standings = tourney.Standings.OrderByDescending(o => o.Wins).ThenBy(x => x.Losses).ToList();


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
