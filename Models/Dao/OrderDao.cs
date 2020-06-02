using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Year_2.Models.Dao
{
    public class OrderDao
    {
        QuanLyNhaHangDBContext context = null;
        public OrderDao()
        {
            context = new QuanLyNhaHangDBContext();
        }
        public long Insert(Order table)
        {
            context.Orders.Add(table);
            context.SaveChanges();
            return table.ID_Table;
        }
        public bool Update(Order entity, int ID)
        {
            try
            {
                var table = context.Orders.Find(ID);
                table.FirstName = entity.FirstName;
                table.LastName = entity.LastName;
                table.PeopleCount = entity.PeopleCount;
                table.Date = entity.Date;
                table.Email = entity.Email;
                table.Message = entity.Message;
                table.Time = entity.Time;
                table.PhoneNumber = entity.PhoneNumber;
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
            var table = context.Orders.Find(ID);
            context.Orders.Remove(table);
            context.SaveChanges();
            return true;
        }
        public Order ViewDetail(int ID)
        {
            return context.Orders.Find(ID);
        }
        public List<Order> ListAll()
        {
            return context.Orders.ToList();
        }
        
    }
}