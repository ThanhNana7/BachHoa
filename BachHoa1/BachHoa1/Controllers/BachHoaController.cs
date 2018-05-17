using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BachHoa1.Models;

namespace BachHoa1.Controllers
{
    public class BachHoaController : Controller
    {
        //dbQLCTyBHDataContext data = new dbQLCTyBHDataContext();
        dbBachHoa data = new dbBachHoa();
        private List<MatHang> Laymathangmoi(int count)
        {
            return data.MatHangs.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public ActionResult Index()
        {

            var mathangmoi = Laymathangmoi(8);
            return View(mathangmoi);
        }

        public ActionResult LoaiHang()
        {
            var loaihang = from lh in data.LoaiHangs select lh;
            return PartialView(loaihang);
        }
        public ActionResult SPTheoloaihang(int id)
        {
            var mathang = from s in data.MatHangs where s.MSLH == id select s;
            return View(mathang);
        }

        public ActionResult Details(int id)
        {
            var mathang = from s in data.MatHangs where s.MSMH == id select s;
            return View(mathang.Single());
        }
        //public ActionResult Dangnhap(FormCollection collection)
        //{
        //    var tendn = collection["TaiKhoan"];
        //    var matkhau = collection["MatKhau"];
        //    if (String.IsNullOrEmpty(tendn))
        //    {
        //        ViewData["Loi1"] = "Vui lòng nhập tên đăng nhập";
        //    }
        //    else if (String.IsNullOrEmpty(matkhau))
        //    {
        //        ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
        //    }
        //    else
        //    {
        //        NVPhuTrach nv = data.NVPhuTraches.SingleOrDefault(n => n.TaiKhoan == tendn && n.MatKhau == matkhau);
        //        if (nv != null)
        //        {
        //            ViewBag.Thongbao = "Đăng nhập thành công";
        //            Session["TaiKhoan"] = nv;
        //        }
        //        else
        //            ViewBag.Thongbao = "Tên đăng nhập hoặc mặt khẩu không đúng";

        //    }
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Login(FormCollection collection)
        //{
        //    var tendn = collection["TaiKhoan"];
        //    var matkhau = collection["MatKhau"];
        //    if (String.IsNullOrEmpty(tendn))
        //    {
        //        ViewData["Loi1"] = "Vui lòng nhập tên đăng nhập";
        //    }
        //    else if (String.IsNullOrEmpty(matkhau))
        //    {
        //        ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
        //    }
        //    else
        //    {
        //        NVPhuTrach nv = data.NVPhuTraches.SingleOrDefault(n => n.TaiKhoan == tendn && n.MatKhau == matkhau);
        //        if (nv != null)
        //        {
        //            ViewBag.Thongbao = "Đăng nhập thành công";
        //            Session["TaiKhoan"] = nv;
        //        }
        //        else
        //            ViewBag.Thongbao = "Tên đăng nhập hoặc mặt khẩu không đúng";

        //    }
        //    return View();
        //}
    }
}