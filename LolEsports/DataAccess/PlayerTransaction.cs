using LolEsports.DataStructures;
using LolEsports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolEsports.DataAccess
{
    public class PlayerTransaction
    {
        public PlayerStructure GetPlayer(int PlayerId)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        PlayerStructure data = new PlayerStructure();
                        Player player = context.Player.Where(i => i.PlayerId == PlayerId).FirstOrDefault();
                        if(player == null)
                        {
                            data.error = 1;
                            data.message = "Player does not exist in the current database.";
                            return data;
                        }
                        Person person = context.Person.Where(i => i.PersonId == player.PersonId).FirstOrDefault();
                        if(person == null)
                        {
                            data.error = 1;
                            data.message = "Player does not have an existing PersonID.";
                            return data;
                        }
                        data.error = 0;
                        data.Age = person.Age;
                        data.Biography = person.Biography;
                        data.Hometown = person.Hometown;
                        data.PersonName = person.PersonName;
                        data.PlayerID = player.PlayerId;
                        data.PlayerIGN = player.PlayerIgn;
                        data.PlayerRole = player.PlayerRole;
                        data.Quote = player.Quote;
                        data.Salary = person.Salary;

                        //Calculate scores
                        int TotalKills = context.PlayerMatchRef.Where(i => i.PlayerId == player.PlayerId).Sum(x => x.PlayerKills);
                        int TotalAssists = context.PlayerMatchRef.Where(i => i.PlayerId == player.PlayerId).Sum(x => x.PlayerAssists);
                        int TotalScore = context.PlayerMatchRef.Where(i => i.PlayerId == player.PlayerId).Sum(x => x.PlayerScore);
                        int TotalDeaths = context.PlayerMatchRef.Where(i => i.PlayerId == player.PlayerId).Sum(x => x.PlayerDeaths);

                        player.TotalKills = TotalKills;
                        player.TotalAssists = TotalAssists;
                        player.TotalScore = TotalScore;
                        player.TotalDeaths = TotalDeaths;
                        context.Update(player);
                        context.SaveChanges();

                        data.TotalAssists = TotalAssists;
                        data.TotalDeaths = TotalDeaths;
                        data.TotalKills = TotalKills;
                        data.TotalScore = TotalScore;
                        data.PlayerImage = player.PlayerImage;

                        int TeamId = context.CompetitorTeamRef.Where(i => i.PlayerId == PlayerId).Select(x => x.TeamId).FirstOrDefault();
                        data.TeamName = context.Team.Where(i => i.TeamId == TeamId).Select(x => x.TeamName).FirstOrDefault();
                        data.TeamImage = context.Team.Where(i => i.TeamId == TeamId).Select(x => x.TeamLogo).FirstOrDefault();

                        dbContextTransaction.Commit();
                        return data;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        PlayerStructure data = new PlayerStructure();
                        data.error = 1;
                        data.message = "Database could not commit the transaction.";
                        return data;
                    }
                }
            }
        }
    }
}
