using LolEsports.DataAccess;
using LolEsports.DataStructures;
using LolEsports.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace LolEsports.Controllers
{
    public class TeamController : Controller
    {
        TeamTransaction transaction = new TeamTransaction();

        [HttpGet]
        [Route("api/GetTeam/{TeamId}")]
        public TeamStructure GetTeam(int TeamId)
        {
            var data = transaction.GetTeam(TeamId);
            return data;
        }
    }
}