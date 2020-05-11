using System;
using System.Collections.Generic;
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
        public ActionResult Home(string SearchString, int page = 1, int pageSize = 10)
        {
            var dao = new StaffDao();
            var model = dao.ListAllPaging(SearchString, page, pageSize);
            ViewBag.SearchString = SearchString;
            return View(model);
        }
        public ActionResult Index(string SearchString, int page = 1, int pageSize = 10)
        {
            var dao = new StaffDao();
            var model = dao.ListAllPaging(SearchString, page, pageSize);
            ViewBag.SearchString = SearchString;
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
        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            new StaffDao().Delete(ID);
            return RedirectToAction("Home");
        }
    }
}