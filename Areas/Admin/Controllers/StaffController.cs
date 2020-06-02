using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Year_2.Models.Dao;
using Project_Year_2.Models.EF;

namespace Project_Year_2.Areas.Admin.Controllers
{
    public class StaffController : BaseController
    {
        // GET: Admin/Guest
        public ActionResult Home( )
        {
            var dao = new StaffDao();
            var model = dao.ListAll();
            return View(model);
        }
        public ActionResult Index()
        {
            var dao = new StaffDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                var dao = new StaffDao();
                if (dao.CheckUserName(staff.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(staff.Email))
                {
                    ModelState.AddModelError("", "Email đã được sử dụng");
                }
                else
                {
                    if (staff.AvatarFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(staff.AvatarFile.FileName);
                        string extension = Path.GetExtension(staff.AvatarFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        staff.Avatar = "~/Assets/Admin/img/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Assets/Admin/img/"), fileName);
                        staff.AvatarFile.SaveAs(fileName);
                    }
                    else
                    {
                        staff.Avatar = "~/Assets/Admin/img/Default_Avatar.png";
                        
                    }
                    var encryptMd5Pass = Common.Encryptor.MD5Hash(staff.Password);
                    staff.Password = encryptMd5Pass;
                    long id = dao.Insert(staff);
                    if (id > 0)
                    {
                        ViewBag.Success = "Đăng kí thành công";
                        staff = new Staff();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm tài khoản nhân viên không thành công");
                    }
                }
                
            }
            return View(staff);
        }
        public ActionResult Edit(int ID)
        {
            var staff = new StaffDao().ViewDetail(ID);
            TempData["ID_Staff"] = ID;
            return View(staff);
        }
        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {

                var dao = new StaffDao();
                if (!string.IsNullOrEmpty(staff.Password))
                {
                    var encryptMd5Pass = Common.Encryptor.MD5Hash(staff.Password);
                    staff.Password = encryptMd5Pass;
                }
                int ID_Staff_Get = int.Parse(TempData["ID_Staff"].ToString());
                var result = dao.Update(staff, ID_Staff_Get);
                if (result)
                {
                    SetAlert("Cập nhập tài khoản thành công", "success");
                    return RedirectToAction("Home", "Staff");
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
            Staff staff = new StaffDao().ViewDetail(ID);
            return View(staff);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            new StaffDao().Delete(ID);
            return RedirectToAction("Home");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new StaffDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}