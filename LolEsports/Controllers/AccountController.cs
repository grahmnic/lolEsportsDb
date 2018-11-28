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
    public class AccountController : Controller
    {
        AccountTransaction transaction = new AccountTransaction();

        [HttpPost]
        [Route("/api/AddAccount")]
        public DataStructure AddAccount([FromBody]Account account)
        {
            var data = transaction.AddAccount(account);
            return data;
        }

        [HttpGet]
        [Route("/api/signin/{user}/{password}")]
        public LoginStructure GetAccount(String user, String password)
        {
            var data = transaction.GetAccount(user, password);
            return data;
        }

        [HttpGet]
        [Route("/api/GetProfile/{id}")]
        public ProfileStructure GetProfile(int id)
        {
            var data = transaction.GetProfile(id);
            return data;
        }

        [HttpPut]
        [Route("/api/changePassword/{id}/{password}")]
        public DataStructure ChangePassword(int id, String password)
        {
            var data = transaction.ChangePassword(id, password);
            return data;
        }

        [HttpDelete]
        [Route("/api/deleteAccount/{id}")]
        public DataStructure DeleteAccount(int id)
        {
            var data = transaction.DeleteAccount(id);
            return data;
        }

        [HttpPut]
        [Route("/api/changeProfilePicture/{id}/{championId}")]
        public DataStructure ChangeProfilePicture(int id, int championId)
        {
            var data = transaction.ChangeProfilePicture(id, championId);
            return data;
        }

        [HttpGet]
        [Route("/api/getChampions")]
        public List<Champion> GetChampions()
        {
            LoLEsportsDbContext context = new LoLEsportsDbContext();
            return context.Champion.ToList();
        }
    }
}