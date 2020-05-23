using Project_Year_2.Areas.Admin.Code;
using Project_Year_2.Areas.Admin.Models;
using Project_Year_2.Common;
using Project_Year_2.Models;
using Project_Year_2.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Project_Year_2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                
                if (result == 1)
                {
                    var user = dao.GetByName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    Session["UserName"] = user.Name.ToString();
                    Session["IDName"] = user.ID.ToString();
                    var image = user.Avatar.ToString();
                    image = image.Substring(1);
                    Session["Avatar"] = image;
                    userSession.UserID = user.ID;
                    Session.Add("USER_SESSION", userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không hợp lệ.");
                }

            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
        }
    }
}