using Project_Year_2.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Year_2.Areas.Admin.Controllers
{
    public class MessageController : BaseController
    {
        // GET: Admin/Message
        public ActionResult Index( int page = 1, int pageSize = 10)
        {
            var dao = new MessageDao();
            var model = dao.ListAllPaging( page, pageSize);
            return View(model);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new MessageDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}