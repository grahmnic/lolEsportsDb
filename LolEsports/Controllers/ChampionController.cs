using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LolEsports.Models;
using Microsoft.AspNetCore.Mvc;

namespace LolEsports.Controllers
{
    public class ChampionController : Controller
    {
        LoLEsportsDbContext context = new LoLEsportsDbContext();

        [HttpGet]
        [Route("api/GetChampion/{id}")]
        public String GetChampion(int id)
        {
            return context.Champion.Where(i => i.ChampionId == id).Select(x => x.ChampionImage).FirstOrDefault();
        }
    }
}