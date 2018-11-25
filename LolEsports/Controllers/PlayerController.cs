using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LolEsports.DataAccess;
using LolEsports.DataStructures;
using Microsoft.AspNetCore.Mvc;

namespace LolEsports.Controllers
{
    public class PlayerController : Controller
    {
        PlayerTransaction transaction = new PlayerTransaction();

        [HttpGet]
        [Route("/api/GetPlayer/{PlayerID}")]
        public PlayerStructure GetPlayer(int PlayerID)
        {
            var data = transaction.GetPlayer(PlayerID);
            return data;
        }
    }
}