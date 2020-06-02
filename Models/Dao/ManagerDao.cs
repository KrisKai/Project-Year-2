using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Year_2.Models.Dao
{
    public class ManagerDao
    {
        QuanLyNhaHangDBContext context = null;  
        public ManagerDao()
        {
            context = new QuanLyNhaHangDBContext();
        }
        public long Insert(Manager account)
        {
            context.Managers.Add(account);
            context.SaveChanges();
            return account.ID;
        }
        public bool Update(Manager entity)
        {
            try
            {
                var user = context.Managers.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.PhoneNumber = entity.PhoneNumber;
                user.IdentityID = entity.IdentityID;
                user.Address = entity.Address;
                user.BirthDay = entity.BirthDay;
                user.Email = entity.Email;
                
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
            var user = context.Managers.Find(ID);
            context.Managers.Remove(user);
            context.SaveChanges();
            return true;
        }
        public List<Manager> ListAll()
        {   
            return context.Managers.ToList();
        }
        public Manager GetByName(string UserName)
        {
            return context.Managers.FirstOrDefault(x=>x.UserName.CompareTo(UserName) == 0);
        }
        public Manager ViewDetail(int ID)
        {
            return context.Managers.Find(ID);
        }
        public int Login(string userName, string passWord)
        {
            var result = context.Managers.FirstOrDefault(x => x.UserName.CompareTo(userName) == 0);
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
            var user = context.Managers.Find(id);
            user.Status = !user.Status;
            context.SaveChanges();
            return user.Status;
        }
        public bool CheckUserName(string username)
        {
            return context.Managers.Count(x => x.UserName == username) > 0;
        }
        public bool UpdateAvatar(int id,Manager account)
        {
            try
            {
                var dao = context.Managers.Find(id);
                dao.Avatar = account.Avatar;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}