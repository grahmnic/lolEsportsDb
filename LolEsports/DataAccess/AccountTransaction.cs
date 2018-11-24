using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LolEsports.Models;
using System.Transactions;
using LolEsports.DataStructures;

namespace LolEsports.DataAccess
{
    public class AccountTransaction
    {
        public LoginStructure GetAccount(String user, String password)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        LoginStructure login = new LoginStructure();
                        Account acc = context.Account.Where(i => i.UserName.Equals(user) && i.Password.Equals(password)).FirstOrDefault();
                        if (acc == null)
                        {
                            login.error = 1;
                            login.message = "Invalid username/password combination.";
                            return login;
                        }
                        login.error = 0;
                        login.UserID = acc.UserId;
                        return login;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        LoginStructure data = new LoginStructure();
                        data.error = 1;
                        data.message = "Database could not commit transaction.";
                        return data;
                    }
                }
            }
        }

        public DataStructure AddAccount(Account account)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                { 
                    try
                    {
                        DataStructure data = new DataStructure();
                        Account acc = context.Account.Where(i => i.UserName.Equals(account.UserName)).FirstOrDefault();
                        if(acc != null)
                        {
                            data.error = 1;
                            data.message = "That username is not available.";
                            return data;
                        }
                        account.LevelAccess = 3;
                        context.Add(account);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        data.error = 0;
                        return data;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        DataStructure data = new DataStructure();
                        data.error = 1;
                        data.message = "Database could not commit transaction.";
                        return data;
                    }
                }
            }
        }
    }
}
