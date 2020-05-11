﻿using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Project_Year_2.Models.Dao
{
    public class UserDao
    {
        QuanLyNhaHangDBContext context = null;  
        public UserDao()
        {
            context = new QuanLyNhaHangDBContext();
        }
        public long Insert(Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
            return account.ID;
        }
        public bool Update(Account entity)
        {
            try
            {
                var user = context.Accounts.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.PhoneNumber = entity.PhoneNumber;
                user.IdentityID = entity.IdentityID;
                user.Address = entity.Address;
                user.role = entity.role;
                context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool Delete(int ID)
        {
            var user = context.Accounts.Find(ID);
            context.Accounts.Remove(user);
            context.SaveChanges();
            return true;
        }
        public IEnumerable<Account> ListAllPaging(string SearchString, int page, int pageSize)
        {
            IQueryable<Account> model = context.Accounts;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.Name.Contains(SearchString) || x.UserName.Contains(SearchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page,pageSize);
        }
        public Account GetByName(string UserName)
        {
            return context.Accounts.FirstOrDefault(x=>x.UserName == UserName);
        }
        public Account ViewDetail(int ID)
        {
            return context.Accounts.Find(ID);
        }
        public int Login(string useName, string passWord)
        {
            var result = context.Accounts.FirstOrDefault(x => x.UserName == useName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public bool ChangeStatus(long id)
        {
            var user = context.Accounts.Find(id);
            user.Status = !user.Status;
            context.SaveChanges();
            return user.Status;
        }
        public bool CheckUserName(string username)
        {
            return context.Accounts.Count(x => x.UserName == username) > 0;
        }
    }
}