using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Configuration;
using System.IO;
using Project_Year_2.Models.EF;
using Project_Year_2.Models.Dao;
using Common;

namespace Project_Year_2.Controllers
{
    public class ConfirmController : Controller
    {
        // GET: Confirm
        private const string ConfirmSession = "ConfirmSession";
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Confirm(string name, string phone, string address, string email, int count, string date, string time)
        {
            var order = new FoodTable();
            order.CreatedDate = DateTime.Now;
            order.LastName = name;
            order.PhoneNumber = phone;
            order.PeopleCount = count;
            order.Email = email;
            order.Date = date;
            order.Time = time;

                long id = new OrderDao().Insert(order);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm đơn đặt bàn không thành công");
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/newOrder.html"));

                content = content.Replace("{{CustomerName}}", name);
                content = content.Replace("{{Phone}}", phone);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{PeopleCount}}", count.ToString());
                content = content.Replace("{{Date}}", date);
                content = content.Replace("{{Time}}", time);
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(email, "Đơn đặt bàn mới từ My Restaurant", content);
                new MailHelper().SendMail(toEmail, "Đơn đặt bàn mới từ My Restaurant", content);
            return View("Index", "Home");

        }
    }
}