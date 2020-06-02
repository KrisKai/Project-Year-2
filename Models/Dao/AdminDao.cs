using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Year_2.Models.Dao
{
    public class AdminDao
    {
        QuanLyNhaHangDBContext context = null;
        public AdminDao()
        {
            context = new QuanLyNhaHangDBContext();
        }
        public Admin GetByName(string UserName)
        {
            return context.Admins.FirstOrDefault(x => x.UserName.CompareTo(UserName) == 0);
        }
        public int Login(string userName, string passWord)
        {
            var result = context.Admins.FirstOrDefault(x => x.UserName.CompareTo(userName) == 0);
            if (result == null)
            {
                return 0;
            }
            else
            {  
                if (result.Password == passWord)
                    return 1;
                else
                    return -2;
                
            }
        }

        public Admin ViewDetail(int ID)
        {
            return context.Admins.Find(ID);
        }
        public bool Update(Admin entity)
        {
            try
            {
                var user = context.Admins.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Admin> ListAll()
        {
            return context.Admins.ToList();
        }
        public bool UpdateAvatar(int id, Admin account)
        {
            try
            {
                var dao = context.Admins.Find(id);
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