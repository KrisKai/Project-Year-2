using PagedList;
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
        public long Insert(FoodTable table)
        {
            context.FoodTables.Add(table);
            context.SaveChanges();
            return table.ID_Table;
        }
        public bool Update(FoodTable entity, int ID)
        {
            try
            {
                var table = context.FoodTables.Find(ID);
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
            var table = context.FoodTables.Find(ID);
            context.FoodTables.Remove(table);
            context.SaveChanges();
            return true;
        }
        public FoodTable ViewDetail(int ID)
        {
            return context.FoodTables.Find(ID);
        }
        public IEnumerable<FoodTable> ListAllPaging(string SearchString, int page, int pageSize)
        {
            IQueryable<FoodTable> model = context.FoodTables;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.LastName.Contains(SearchString));
            }
            return model.OrderByDescending(x => x.LastName).ToPagedList(page, pageSize);
        }
        
    }
}