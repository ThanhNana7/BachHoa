using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BH.Models;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;
using System.Net;
using System.Data.Entity;

namespace BH.Controllers
{
    public class NVThanhToanController : Controller
    {
        // GET: NVThanhToan
        dbBachHoa db = new dbBachHoa();

        //DANGNHAP
        [HttpPost]
        public ActionResult Login(FormCollection collection)
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
                    return RedirectToAction("Index", "NVThanhToan");
                }
                else
                    ViewBag.Thongbao = "Tài khoản hoặc mật khẩu không đúng";
            }
            return View();
        }


        //TRANG CHỦ
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> ChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVThanhToan nVThanhToan = await db.NVThanhToans.FindAsync(id);
            if (nVThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(nVThanhToan);
        }
        

        //CUAHANG
        // GET: CuaHangs
        public async Task<ActionResult> CuaHang(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.CuaHangs.ToList().OrderBy(n => n.MSCH).ToPagedList(pageNumber, pageSize));
        }

        // GET: CuaHangs/Details/5
        public async Task<ActionResult> CH_ChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = await db.CuaHangs.FindAsync(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }
        // GET: CuaHangs/Create
        public ActionResult CH_Them()
        {
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang");
            ViewBag.NvPhuTrach = new SelectList(db.NVPhuTraches, "MSNV", "HoTen");
            return View();
        }
        // POST: CuaHangs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CH_Them([Bind(Include = "MSCH,TenCH,MSLH,DiaChi,NvPhuTrach,SDT")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                db.CuaHangs.Add(cuaHang);
                await db.SaveChangesAsync();
                return RedirectToAction("CuaHang");
            }

            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", cuaHang.MSLH);
            ViewBag.NvPhuTrach = new SelectList(db.NVPhuTraches, "MSNV", "HoTen", cuaHang.NvPhuTrach);
            return View(cuaHang);
        }
        // GET: CuaHangs/Edit/5
        public async Task<ActionResult> CH_Sua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = await db.CuaHangs.FindAsync(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", cuaHang.MSLH);
            ViewBag.NvPhuTrach = new SelectList(db.NVPhuTraches, "MSNV", "HoTen", cuaHang.NvPhuTrach);
            return View(cuaHang);
        }
        // POST: CuaHangs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CH_Sua([Bind(Include = "MSCH,TenCH,MSLH,DiaChi,NvPhuTrach,SDT")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuaHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("CuaHang");
            }
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", cuaHang.MSLH);
            ViewBag.NvPhuTrach = new SelectList(db.NVPhuTraches, "MSNV", "HoTen", cuaHang.NvPhuTrach);
            return View(cuaHang);
        }
        // GET: CuaHangs/Delete/5
        public async Task<ActionResult> CH_Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = await db.CuaHangs.FindAsync(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }
        // POST: CuaHangs/Delete/5
        [HttpPost, ActionName("CH_Xoa")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CH_XoaConfirmed(int id)
        {
            CuaHang cuaHang = await db.CuaHangs.FindAsync(id);
            db.CuaHangs.Remove(cuaHang);
            await db.SaveChangesAsync();
            return RedirectToAction("CuaHang");
        }


        //lOẠI HÀNG 
        // GET: LoaiHangs
        public async Task<ActionResult> LoaiHang(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.LoaiHangs.ToList().OrderBy(n => n.MSLH).ToPagedList(pageNumber, pageSize));
        }
        // GET: LoaiHangs/Details/5
        public async Task<ActionResult> LH_ChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = await db.LoaiHangs.FindAsync(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }
        // GET: LoaiHangs/Create
        public ActionResult LH_Them()
        {
            return View();
        }

        // POST: LoaiHangs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LH_Them([Bind(Include = "MSLH,TenLoaiHang,HinhAnh")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHangs.Add(loaiHang);
                await db.SaveChangesAsync();
                return RedirectToAction("LoaiHang");
            }

            return View(loaiHang);
        }
        // GET: LoaiHangs/Edit/5
        public async Task<ActionResult> LH_Sua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = await db.LoaiHangs.FindAsync(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }
        // POST: LoaiHangs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LH_Sua([Bind(Include = "MSLH,TenLoaiHang,HinhAnh")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("LoaiHang");
            }
            return View(loaiHang);
        }
        // GET: LoaiHangs/Delete/5
        public async Task<ActionResult> LH_Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHang loaiHang = await db.LoaiHangs.FindAsync(id);
            if (loaiHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiHang);
        }
        // POST: LoaiHangs/Delete/5
        [HttpPost, ActionName("LH_Xoa")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LH_XoaConfirmed(int id)
        {
            LoaiHang loaiHang = await db.LoaiHangs.FindAsync(id);
            db.LoaiHangs.Remove(loaiHang);
            await db.SaveChangesAsync();
            return RedirectToAction("LoaiHang");
        }


        //NHANVIEN
        // GET: NVPhuTraches
        public async Task<ActionResult> NhanVien(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.NVPhuTraches.ToList().OrderBy(n => n.MSNV).ToPagedList(pageNumber, pageSize));
        }
        // GET: NVPhuTraches/Details/5
        public async Task<ActionResult> NV_ChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVPhuTrach nVPhuTrach = await db.NVPhuTraches.FindAsync(id);
            if (nVPhuTrach == null)
            {
                return HttpNotFound();
            }
            return View(nVPhuTrach);
        }
        // GET: NVPhuTraches/Create
        public ActionResult NV_Them()
        {
            return View();
        }
        // POST: NVPhuTraches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NV_Them([Bind(Include = "MSNV,HoTen,Phai,NamSinh,DiaChi,SDT,TaiKhoan,MatKhau")] NVPhuTrach nVPhuTrach)
        {
            if (ModelState.IsValid)
            {
                db.NVPhuTraches.Add(nVPhuTrach);
                await db.SaveChangesAsync();
                return RedirectToAction("NhanVien");
            }

            return View(nVPhuTrach);
        }
        // GET: NVPhuTraches/Edit/5
        public async Task<ActionResult> NV_Sua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVPhuTrach nVPhuTrach = await db.NVPhuTraches.FindAsync(id);
            if (nVPhuTrach == null)
            {
                return HttpNotFound();
            }
            return View(nVPhuTrach);
        }
        // POST: NVPhuTraches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NV_Sua([Bind(Include = "MSNV,HoTen,Phai,NamSinh,DiaChi,SDT,TaiKhoan,MatKhau")] NVPhuTrach nVPhuTrach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nVPhuTrach).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("NhanVien");
            }
            return View(nVPhuTrach);
        }
        // GET: NVPhuTraches/Delete/5
        public async Task<ActionResult> NV_Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVPhuTrach nVPhuTrach = await db.NVPhuTraches.FindAsync(id);
            if (nVPhuTrach == null)
            {
                return HttpNotFound();
            }
            return View(nVPhuTrach);
        }
        // POST: NVPhuTraches/Delete/5
        [HttpPost, ActionName("NV_Xoa")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NV_XoaConfirmed(int id)
        {
            NVPhuTrach nVPhuTrach = await db.NVPhuTraches.FindAsync(id);
            db.NVPhuTraches.Remove(nVPhuTrach);
            await db.SaveChangesAsync();
            return RedirectToAction("NhanVien");
        }


        //PhIEUTHU
        public ActionResult PhieuThu()
        {
            return View();
        }
        

        //DOANHTHU
        public ActionResult DoanhThu()
        {
            return View();
        }


        //TAIKHOAN 
        public ActionResult TaiKhoan()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }     
    }
}