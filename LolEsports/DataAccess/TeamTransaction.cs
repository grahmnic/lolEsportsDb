using LolEsports.DataStructures;
using LolEsports.Models;
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
                        if (coach != null)
                        {
                            data.error = 1;
                            data.message = "There is no coach available for this team.";
                            return data;
                        }

                        Team team = context.Team.Where(i => i.TeamId == TeamId).FirstOrDefault();
                        data.TeamLogo = team.TeamLogo;
                        data.TeamName = team.TeamName;
                        data.TeamPicture = team.TeamPicture;
                        PlayerTransaction pTransaction = new PlayerTransaction();
                        //data.Coach = 

                        dbContextTransaction.Commit();
                        data.error = 0;
                        return data;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        TeamStructure data = new TeamStructure();
                        data.error = 1;
                        data.message = "Database could not commit transaction.";

                        return data;
                    }
                }
            }
        }
    }
}
