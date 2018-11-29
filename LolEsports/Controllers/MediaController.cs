using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LolEsports.Models;
using Microsoft.AspNetCore.Mvc;

namespace LolEsports.Controllers
{
    public class MediaController : Controller
    {
        LoLEsportsDbContext context = new LoLEsportsDbContext();

        [HttpGet]
        [Route("/api/getMedia")]
        public List<Media> GetMedia()
        {
            return context.Media.ToList();
        }
    }
}