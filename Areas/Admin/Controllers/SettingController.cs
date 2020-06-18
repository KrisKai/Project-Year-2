using Project_Year_2.Areas.Admin.Models;
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
            QuanLyNhaHangDBContext context = new QuanLyNhaHangDBContext();
            
            var user = context.Accounts.Find(Convert.ToInt32(Session["IDName"].ToString()));
                
            
            return View(user);
        }
        [HttpPost]
        public ActionResult Update(Account account)
        {
            if (ModelState.IsValid)
            {
                Boolean result = false;
                try
                {
                    var dao = new UserDao();
                    QuanLyNhaHangDBContext context = new QuanLyNhaHangDBContext();
                    var user = context.Accounts.Find(Convert.ToInt32(Session["IDName"].ToString()));

                    if (!string.IsNullOrEmpty(account.Password))
                    {
                        var encryptMd5Pass = Common.Encryptor.MD5Hash(account.Password);
                        var encryptMd5ConPass = Common.Encryptor.MD5Hash(account.ConfirmPassword);
                        if(user.Password == encryptMd5Pass && user.Password == encryptMd5ConPass)
                        {
                            user.User_Infor.Name = account.User_Infor.Name;
                            user.User_Infor.PhoneNumber = account.User_Infor.PhoneNumber;
                            user.User_Infor.IdentityID = account.User_Infor.IdentityID;
                            user.User_Infor.Address = account.User_Infor.Address;
                            user.User_Infor.BirthDay = account.User_Infor.BirthDay;
                            user.User_Infor.Email = account.User_Infor.Email;
                            context.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Nhập mật khẩu sai");
                        }
                        
                    }
                    //var user = new ConfirmModel();
                    
                }
                catch(Exception)
                {
                    result = false;
                }


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
            return RedirectToAction("Index");
        }
    }
}