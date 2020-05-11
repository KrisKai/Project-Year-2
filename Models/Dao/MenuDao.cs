using PagedList;
using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Project_Year_2.Models.Dao
{
    public class MenuDao
    {
        QuanLyNhaHangDBContext context = null;
        public MenuDao()
        {
            context = new QuanLyNhaHangDBContext();
        }
        public long Insert(Food food)
        {
            context.Foods.Add(food);
            context.SaveChanges();
            return food.ID_Food;
        }
        public bool Update(Food entity, int ID)
        {
            try
            {
                var food = context.Foods.Find(ID);
                food.Name = entity.Name;
                food.Price = entity.Price;
                food.Code = entity.Code;
                food.ImagePath = entity.ImagePath;
                food.Description = entity.Description;
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
            var food = context.Foods.Find(ID);
            context.Foods.Remove(food);
            context.SaveChanges();
            return true;
        }
        public Food ViewDetail(int ID)
        {
            return context.Foods.Find(ID);
        }
        public IEnumerable<Food> ListAllPaging(string SearchString, int page, int pageSize)
        {
            IQueryable<Food> model = context.Foods;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.Name.Contains(SearchString));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var food = context.Foods.Find(id);
            food.Status = !food.Status;
            context.SaveChanges();
            return food.Status;
        }
        public bool CheckName(string name)
        {
            return context.Foods.Count(x => x.Name == name) > 0;
        }
    }
    

}