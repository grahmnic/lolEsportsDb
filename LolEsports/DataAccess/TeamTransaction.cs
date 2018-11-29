using LolEsports.DataStructures;
using LolEsports.Models;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolEsports.DataAccess
{
    public class TeamTransaction
    {
        public TeamStructure GetTeam(int TeamId)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        TeamStructure data = new TeamStructure();
                        Coach coach = context.Coach.Where(i => i.CoachId == context.CompetitorTeamRef.Where(x => x.TeamId == TeamId).Select(m => m.CoachId).FirstOrDefault()).FirstOrDefault();
                       
                        if (coach == null)
                        {
                            data.error = 1;
                            data.message = "There is no coach available for this team.";
                            return data;
                        }
                        Person coachPerson = context.Person.Where(i => i.PersonId == coach.PersonId).FirstOrDefault();
                        Team team = context.Team.Where(i => i.TeamId == TeamId).FirstOrDefault();
                        data.TeamLogo = team.TeamLogo;
                        data.TeamName = team.TeamName;
                        data.TeamPicture = team.TeamPicture;
                        data.TeamId = TeamId;

                        data.CoachName = coachPerson.PersonName;
                        data.CoachIgn = coach.CoachIgn;
                        data.ids = new List<int>();

                        var t = context.CompetitorTeamRef.Where(i => i.TeamId == TeamId).Select(x => x.PlayerId).ToList();
                        t.ForEach(x =>
                        {
                            data.ids.Add(x);
                        });

                        dbContextTransaction.Commit();
                        data.error = 0;
                        return data;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        TeamStructure data = new TeamStructure();
                        data.error = 1;
                        data.message = e.ToString();

                        return data;
                    }
                }
            }
        }
    }
}
