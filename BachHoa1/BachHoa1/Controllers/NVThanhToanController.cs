using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BachHoa1.Models;

using System.IO;

namespace BachHoa1.Controllers
{
    public class NVThanhToanController : Controller
    {
        dbBachHoa db = new dbBachHoa();
        // GET: NVThanhToan
        [HttpGet]
        public ActionResult Login()
        {
          return View();
        }
        [HttpPost]
        public ActionResult Login( FormCollection collection)
        {
            dbBachHoa db = new dbBachHoa();
            var tendn = collection["TaiKhoan"];
            var matkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Coloi"] = "Vui lòng nhập tên tài khoản";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Coloi1"] = "Vui lòng nhập mật khẩu";
            }
            else
            {
                NVThanhToan nv = db.NVThanhToans.SingleOrDefault(n => n.TaiKhoan == tendn && n.MatKhau == matkhau);
                if (nv != null)
                {
                    Session["TaiKhoan"] = nv;
                    return RedirectToAction( "Index","MatHangs");
                }
                else
                    ViewBag.Thongbao = "Tài khoản hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}