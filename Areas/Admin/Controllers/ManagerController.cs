using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project_Year_2.Models.Dao;
using Project_Year_2.Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Project_Year_2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : BaseController
    {
        // GET: Admin/Manager
        public ActionResult Home()
        {
            var dao = new UserDao();
            var model = dao.ListAll_Manager();
            return View(model);
        }
        public ActionResult Index( )
        {
            var dao = new UserDao();
            var model = dao.ListAll_Manager();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        
        [HttpPost]
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDao();
                if (dao.CheckUserName(account.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var encryptMd5Pass = Common.Encryptor.MD5Hash(account.Password);
                    account.Password = encryptMd5Pass;
                    long id = dao.Insert(account);
                    if (id > 0)
                    {
                        ViewBag.Success = "Đăng kí thành công";
                        account = new Account();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm tài khoản thành công");
                    }
                }                
            }
            return View(account);
        }
        public ActionResult AddInfor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInfor(int ID,User_Infor entity)
        {
            var infor = new UserDao();
            entity.ID = ID;
            if (infor.CheckEmail(entity.Email))
            {
                ModelState.AddModelError("", "Email đã được sử dụng");
            }
            else
            {
                if (entity.AvatarFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(entity.AvatarFile.FileName);
                    string extension = Path.GetExtension(entity.AvatarFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    entity.Avatar = "~/Assets/Admin/img/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Assets/Admin/img/"), fileName);
                    entity.AvatarFile.SaveAs(fileName);
                }
                else
                {
                    entity.Avatar = "~/Assets/Admin/img/Default_Avatar.png";

                }
                long user = infor.InsertInfor(entity);
                if (user > 0)
                {
                    SetAlert("Cập nhập tài khoản thành công", "success");
                    return RedirectToAction("Home", "Manager");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập tài khoản không thành công");
                }
            }
            
            return View();
        }
        public ActionResult Edit(int ID)
        {
            var account = new UserDao().ViewDetail(ID);
            return View(account);
        }
        [HttpPost]
        public ActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDao();
                if (!string.IsNullOrEmpty(account.Password))
                {
                    var encryptMd5Pass = Common.Encryptor.MD5Hash(account.Password);
                    account.Password = encryptMd5Pass;
                }
                if (account.User_Infor.AvatarFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(account.User_Infor.AvatarFile.FileName);
                    string extension = Path.GetExtension(account.User_Infor.AvatarFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    account.User_Infor.Avatar = "~/Assets/Admin/img/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Assets/Admin/img/"), fileName);
                    account.User_Infor.AvatarFile.SaveAs(fileName);
                }
                else
                {
                    account.User_Infor.Avatar = "~/Assets/Admin/img/Default_Avatar.png";

                }
                var result = dao.Update(account);
                if (result)
                {
                    SetAlert("Cập nhập tài khoản thành công", "success");
                    return RedirectToAction("Home", "Manager");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập tài khoản không thành công");
                }
            }
            return View("Home");
        }
        
        public ActionResult Delete(int ID)
        {
            Account account = new UserDao().ViewDetail(ID);
            return View(account);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            new UserDao().Delete(ID);
            return RedirectToAction("Home");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}