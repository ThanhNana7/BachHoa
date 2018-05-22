using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BH.Models;
using PagedList;
using PagedList.Mvc;
using System.Net;
using System.Data.Entity;

namespace BH.Controllers
{
    public class NVPhuTrachController : Controller
    {
        dbBachHoa db = new dbBachHoa();
        // GET: NVPhuTrach
        //TRANG CHỦ
        public ActionResult Index()
        {
            return View();
        }


        //MATHANG
        // GET: MatHangs
        public async Task<ActionResult> MatHang(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.MatHangs.ToList().OrderBy(n => n.MSMH).ToPagedList(pageNumber, pageSize));
        }

        // GET: MatHangs/Details/5
        public async Task<ActionResult> MH_ChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = await db.MatHangs.FindAsync(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }
        // GET: MatHangs/Create
        public ActionResult MH_Them()
        {
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang");
            return View();
        }
        // POST: MatHangs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MH_Them([Bind(Include = "MSMH,MSLH,TenHang,SoLuong,TrangThai,DonGia,HinhAnh,NgayCapNhat")] MatHang matHang)
        {
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", matHang.MSLH);
            if (ModelState.IsValid)
            {
                db.MatHangs.Add(matHang);
                await db.SaveChangesAsync();
                return RedirectToAction("MatHang");
            }
            return View(matHang);
        }
        // GET: MatHangs/Edit/5
        public async Task<ActionResult> MH_Sua(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = await db.MatHangs.FindAsync(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", matHang.MSLH);
            return View(matHang);
        }
        // POST: MatHangs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MH_Sua([Bind(Include = "MSMH,MSLH,TenHang,SoLuong,TrangThai,DonGia,HinhAnh,NgayCapNhat")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("MatHang");
            }
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", matHang.MSLH);
            return View(matHang);
        }
        // GET: MatHangs/Delete/5
        public async Task<ActionResult> MH_Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = await db.MatHangs.FindAsync(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // POST: MatHangs/Delete/5
        [HttpPost, ActionName("MH_Xoa")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MH_XoaConfirmed(int id)
        {
            MatHang matHang = await db.MatHangs.FindAsync(id);
            db.MatHangs.Remove(matHang);
            await db.SaveChangesAsync();
            return RedirectToAction("MatHang");
        }

        //PHIEUGIAO
        public ActionResult PhieuGiao()
        {
            return View();
        }

        //BAOCAO
        public ActionResult BaoCao()
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