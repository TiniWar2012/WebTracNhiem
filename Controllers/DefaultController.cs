using BTL_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_CNPM.Controllers
{
    public class DefaultController : Controller
    {
        private DBEntities db = new DBEntities();
        // GET: Admin/Default
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            var urs = username;
            var pwd = password;
            var acc = db.NguoiQuanLies.SingleOrDefault(x => x.TaiKhoan == urs && x.MatKhau == pwd);
            if (acc != null)
            {
                // Đăng nhập thành công
                Session["admin"] = acc;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
    }
}