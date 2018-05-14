using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BachHoa.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace BachHoa.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        dbQLCTyBHDataContext db = new dbQLCTyBHDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MatHang(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.MatHangs.ToList().OrderBy(n => n.MSMH).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            dbQLCTyBHDataContext db = new dbQLCTyBHDataContext();
            var tendn = collection["ID"];
            var matkhau = collection["Pass"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                Admin ad = db.Admins.SingleOrDefault(n => n.ID == tendn && n.Pass == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Themmoimathang()
        {
            ViewBag.MSLH = new SelectList(db.LoaiHangs.ToList().OrderBy(n => n.TenLoaiHang), "MSLH", "TenLoaiHang");           
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Themmoimathang(MatHang mathang, HttpPostedFileBase fileUpload)
        {
            ViewBag.MSLH = new SelectList(db.LoaiHangs.ToList().OrderBy(n => n.TenLoaiHang), "MSLH", "TenLoaiHang");       
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh/HinhAnh(MatHang)"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    mathang.HinhAnh = fileName;
                    db.MatHangs.InsertOnSubmit(mathang);
                    db.SubmitChanges();
                }
                return RedirectToAction("MatHang");
            }
        }

        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Suamathang(int id)
        {
            //Lay ra doi tuong sach theo ma
            MatHang mathang = db.MatHangs.SingleOrDefault(n => n.MSMH == id);
            if (mathang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownList
            //Lay ds tu table chu de, sap xep tang dan theo ten chu de, chon lay gia tri ma CD, hien thi Tenchude
            ViewBag.MSLH = new SelectList(db.LoaiHangs.ToList().OrderBy(n => n.TenLoaiHang), "MSLH", "TenLoaiHang", mathang.MSLH);       
            return View(mathang);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Suamathang(MatHang mathang, HttpPostedFileBase fileUpLoad)
        {
            //Dua du lieu vao Dropdownload
            ViewBag.MSLH = new SelectList(db.LoaiHangs.ToList().OrderBy(n => n.TenLoaiHang), "MSLH", "Ten");
            //Kiem tra duong dan file
            if (fileUpLoad == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten file, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpLoad.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/HinhAnh/HinhAnh(MatHang)"), fileName);
                    //Kiem tra hinh anh ton tai chua ?
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        //Luu hinh anh vao duong dan
                        fileUpLoad.SaveAs(path);
                    }
                    //sach.Hinhminhhoa = fileName;
                    ////Luu vao CSDL
                    //UpdateModel(sach);
                    //db.SubmitChanges();

                    MatHang s = db.MatHangs.Where(x => x.MSMH == mathang.MSMH).Single<MatHang>();
                    s.MSLH = mathang.MSLH;
                    s.TenHang = mathang.TenHang;
                    s.SoLuong = mathang.SoLuong;
                    s.DonGia = mathang.DonGia;
                    s.TrangThai = mathang.TrangThai;
                    s.HinhAnh= fileName;
                    db.SubmitChanges();
                }
                return RedirectToAction("Sach");
            }
        }
        public ActionResult Chitietmathang(int id)
        {
            MatHang mathang = db.MatHangs.SingleOrDefault(n => n.MSMH == id);
            ViewBag.MSMH = mathang.MSMH;
            if (mathang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(mathang);
        }

        [HttpGet]
        public ActionResult Xoamathang(int id)
        {
            MatHang mathang = db.MatHangs.SingleOrDefault(n => n.MSMH == id);
            ViewBag.MSMH = mathang.MSMH;
            if (mathang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(mathang);
        }

        [HttpPost, ActionName("Xoamathang")]
        public ActionResult Xacnhanxoa(int id)
        {
            MatHang mathang = db.MatHangs.SingleOrDefault(n => n.MSMH == id);
            ViewBag.MSMH = mathang.MSMH;
            if (mathang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.MatHangs.DeleteOnSubmit(mathang);
            db.SubmitChanges();
            return RedirectToAction("MatHang");
        }
    }
}