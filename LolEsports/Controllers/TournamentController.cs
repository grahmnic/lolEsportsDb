using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LolEsports.DataAccess;
using LolEsports.DataStructures;
using Microsoft.AspNetCore.Mvc;

namespace LolEsports.Controllers
{
    public class TournamentController : Controller
    {
        TournamentTransaction transaction = new TournamentTransaction();

        [HttpGet]
        [Route("api/GetTournament/{id}")]
        public TournamentStructure GetTeam(int id)
        {
            var data = transaction.GetTournament(id);
            return data;
        }
    }
}