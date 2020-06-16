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
        public List<Message> ListAll()
        {
            return context.Messages.OrderBy(x => x.Name).ToList();
        }
        public bool ChangeStatus(long id)
        {
            var message = context.Messages.Find(id);
            message.Status = !message.Status;
            context.SaveChanges();
            return message.Status;
        }
        public bool Delete(int ID)
        {
            var message = context.Messages.Find(ID);
            context.Messages.Remove(message);
            context.SaveChanges();
            return true;
        }
        public Message ViewDetail(int ID)
        {
            return context.Messages.Find(ID);
        }
    }
}