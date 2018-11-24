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
        public DataStructure AddAccount(Account account)
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
    }
}