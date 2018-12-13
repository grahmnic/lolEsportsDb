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
                        login.ChampionImage = context.Champion.Where(i => i.ChampionId == acc.ChampionId).Select(x => x.ChampionImage).FirstOrDefault();
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
                        account.ChampionId = 1;
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

        public ProfileStructure GetProfile(int id)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ProfileStructure newProf = new ProfileStructure();
                        Account acc = context.Account.Where(x => x.UserId == id).FirstOrDefault();
                        newProf.UserID = acc.UserId;
                        newProf.UserName = acc.UserName;
                        newProf.ChampionImage = context.Champion.Where(x => x.ChampionId == acc.ChampionId).Select(y => y.ChampionImage).FirstOrDefault();
                        newProf.error = 0;
                        dbContextTransaction.Commit();
                        return newProf;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        ProfileStructure data = new ProfileStructure();
                        data.error = 1;
                        data.message = "Database could not commit transaction.";
                        return data;
                    }
                }
            }
        }

        public DataStructure ChangePassword(int id, String password)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        DataStructure data = new DataStructure();
                        Account acc = context.Account.Where(i => i.UserId == id).FirstOrDefault();
                        if(acc == null)
                        {
                            data.error = 1;
                            data.message = "Account does not exist.";
                            return data;
                        }
                        acc.Password = password;
                        context.Update(acc);
                        context.SaveChanges();
                        data.error = 0;
                        data.message = "Successfully changed password.";
                        dbContextTransaction.Commit();
                        return data;
                    }
                    catch (Exception e)
                    {
                        DataStructure data = new DataStructure();
                        data.error = 1;
                        data.message = e.ToString();
                        dbContextTransaction.Rollback();
                        return data;
                    }
                }
            }
        }

        public DataStructure DeleteAccount(int id)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        DataStructure data = new DataStructure();
                        Account acc = context.Account.Where(i => i.UserId == id).FirstOrDefault();
                        if(acc == null)
                        {
                            data.error = 1;
                            data.message = "Account does not exist.";
                            return data;
                        }
                        context.Remove(acc);
                        context.SaveChanges();
                        data.error = 0;
                        data.message = "Account successfully deleted.";
                        dbContextTransaction.Commit();
                        return data;
                    }
                    catch (Exception e)
                    {
                        DataStructure data = new DataStructure();
                        data.error = 1;
                        data.message = e.ToString();
                        dbContextTransaction.Rollback();
                        return data;
                    }
                }
            }
        }

        public DataStructure ChangeProfilePicture(int id, int championId)
        {
            using (var context = new LoLEsportsDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        DataStructure data = new DataStructure();
                        Account acc = context.Account.Where(i => i.UserId == id).FirstOrDefault();
                        if (acc == null)
                        {
                            data.error = 1;
                            data.message = "Account does not exist.";
                            return data;
                        }
                        acc.ChampionId = championId;
                        context.Update(acc);
                        context.SaveChanges();
                        data.error = 0;
                        data.message = "ChampionId successfully changed";
                        dbContextTransaction.Commit();
                        return data; 
                    }
                    
                    catch (Exception e)
                    {
                        DataStructure data = new DataStructure();
                        data.error = 1;
                        data.message = e.ToString();
                        dbContextTransaction.Rollback();
                        return data;
                    }
                }
            }
        }
    }
}
