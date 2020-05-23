using PagedList;
using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Year_2.Models.Dao
{
    public class StaffDao
    {
        QuanLyNhaHangDBContext context = null;
        public StaffDao()
        {
            context = new QuanLyNhaHangDBContext();
        }
        public long Insert(Staff staff)
        {
            context.Staffs.Add(staff);
            context.SaveChanges();
            return staff.ID_Staff;
        }
        public bool Update(Staff entity, int ID)
        {
            try
            {
                var user = context.Staffs.Find(ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.PhoneNumber = entity.PhoneNumber;
                user.IdentityID = entity.IdentityID;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.BirthDay = entity.BirthDay;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int ID)
        {
            var user = context.Staffs.Find(ID);
            context.Staffs.Remove(user);
            context.SaveChanges();
            return true;
        }
        public IEnumerable<Staff> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Staff> model = context.Staffs;
            
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
        public Staff GetByName(string UserName)
        {
            return context.Staffs.FirstOrDefault(x => x.UserName == UserName);
        }
        public Staff ViewDetail(int ID)
        {
            return context.Staffs.Find(ID);
        }
        public int Login(string userName, string passWord)
        {
            var result = context.Staffs.FirstOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
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
            var staff = context.Staffs.Find(id);
            staff.Status = !staff.Status;
            context.SaveChanges();
            return staff.Status;
        }
        public bool CheckUserName(string username)
        {
            return context.Staffs.Count(x => x.UserName == username) > 0;
        }
        public bool CheckEmail(string email)
        {
            return context.Staffs.Count(x => x.Email == email) > 0;
        }
    }
}