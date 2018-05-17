using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BachHoa1.Models;
using PagedList;
using PagedList.Mvc;

namespace BachHoa1.Controllers
{
    public class MatHangsController : Controller
    {
        private dbBachHoa db = new dbBachHoa();

        // GET: MatHangs
        public async Task<ActionResult> Index(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.MatHangs.ToList().OrderBy(n => n.MSMH).ToPagedList(pageNumber, pageSize));
        }

        // GET: MatHangs/Details/5
        public async Task<ActionResult> Details(int? id)
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
        public ActionResult Create()
        {
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang");
            return View();
        }

        // POST: MatHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MSMH,MSLH,TenHang,SoLuong,TrangThai,DonGia,HinhAnh,NgayCapNhat")] MatHang matHang)
        {
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", matHang.MSLH);
            if (ModelState.IsValid)
            {
                db.MatHangs.Add(matHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }           
            return View(matHang);
        }

        // GET: MatHangs/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MSMH,MSLH,TenHang,SoLuong,TrangThai,DonGia,HinhAnh,NgayCapNhat")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", matHang.MSLH);
            return View(matHang);
        }

        // GET: MatHangs/Delete/5
        public async Task<ActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MatHang matHang = await db.MatHangs.FindAsync(id);
            db.MatHangs.Remove(matHang);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
