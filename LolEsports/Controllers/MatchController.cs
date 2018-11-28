using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LolEsports.DataAccess;
using LolEsports.DataStructures;
using Microsoft.AspNetCore.Mvc;

namespace LolEsports.Controllers
{
    public class MatchController : Controller
    {
        MatchTransaction transaction = new MatchTransaction();

        [HttpGet]
        [Route("/api/GetMatch/{id}")]
        public MatchStructure GetPlayer(int id)
        {
            var data = transaction.GetMatch(id);
            return data;
        }
    }
}