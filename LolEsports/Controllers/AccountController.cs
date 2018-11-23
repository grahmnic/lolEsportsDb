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
    [Route("/api/account")]
    public class AccountController : Controller
    {
        AccountTransaction transaction = new AccountTransaction();

        [HttpPost]
        [Route("/add")]
        public DataStructure AddAccount(Account account)
        {
            var data = transaction.AddAccount(account);
            return data;
        }

        [HttpGet]
        [Route("/signin/{user}/{password}")]
        public LoginStructure GetAccount(String user, String password)
        {
            var data = transaction.GetAccount(user, password);
            return data;
        }
    }
}