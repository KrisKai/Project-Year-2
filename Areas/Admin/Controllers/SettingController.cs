using Project_Year_2.Models.Dao;
using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Year_2.Areas.Admin.Controllers
{
    public class SettingController : BaseController
    {
        // GET: Admin/Setting

        public ActionResult Index()
        {
            int id = int.Parse(Session["IDName"].ToString());
            var account = new AdminDao().ViewDetail(id);
            return View(account);
        }
        [HttpPost]
        public ActionResult Index(Project_Year_2.Models.EF.Admin account)
        {
            if (ModelState.IsValid)
            {

                var dao = new AdminDao();
                if (!string.IsNullOrEmpty(account.Password))
                {
                    var encryptMd5Pass = Common.Encryptor.MD5Hash(account.Password);
                    account.Password = encryptMd5Pass;
                }
                var result = dao.Update(account);
                if (result)
                {
                    SetAlert("Cập nhập tài khoản cá nhân thành công", "success");
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập không thành công");
                }
            }
            return View("Home");
        }
    }
}