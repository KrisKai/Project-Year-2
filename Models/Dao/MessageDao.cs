using PagedList;
using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Year_2.Models.Dao
{
    public class MessageDao
    {
        QuanLyNhaHangDBContext context = null;
        public MessageDao()
        {
            context = new QuanLyNhaHangDBContext();
        }
        public long Insert(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return message.ID_Message;
        }
        public IEnumerable<Message> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Message> model = context.Messages;
            
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var message = context.Messages.Find(id);
            message.Status = !message.Status;
            context.SaveChanges();
            return message.Status;
        }
    }
}