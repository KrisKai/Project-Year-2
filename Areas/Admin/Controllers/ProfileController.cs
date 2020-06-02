using Project_Year_2.Models.Dao;
using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Year_2.Areas.Admin.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Admin/Profile
        public ActionResult Index()
        {
            int id = int.Parse(Session["IDName"].ToString());
            var account = new AdminDao().ViewDetail(id);
            return View(account);
        }
        [HttpPost]
        public ActionResult Index(Project_Year_2.Models.EF.Admin account)
        {
            if (account.AvatarFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(account.AvatarFile.FileName);
                string extension = Path.GetExtension(account.AvatarFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                account.Avatar = "~/Assets/Admin/img/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Assets/Admin/img/"), fileName);
                account.AvatarFile.SaveAs(fileName);
            }
            int id = int.Parse(Session["IDName"].ToString());
            var user = new AdminDao().UpdateAvatar(id, account);
            if (user)
            {
                SetAlert("Cập nhập ảnh đại diện thành công", "success");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhập tài khoản không thành công");
            }
            var image = account.Avatar.ToString();
            image = image.Substring(1);
            Session["Avatar"] = image;
            return View(account);
        }
    }
}