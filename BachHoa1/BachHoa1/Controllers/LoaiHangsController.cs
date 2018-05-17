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
    public class LoaiHangsController : Controller
    {
        private dbBachHoa db = new dbBachHoa();

        // GET: LoaiHangs
        public async Task<ActionResult> Index(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.LoaiHangs.ToList().OrderBy(n => n.MSLH).ToPagedList(pageNumber, pageSize));
        }

        // GET: LoaiHangs/Details/5
        public async Task<ActionResult> Details(int? id)
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MSLH,TenLoaiHang,HinhAnh")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHangs.Add(loaiHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loaiHang);
        }

        // GET: LoaiHangs/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MSLH,TenLoaiHang,HinhAnh")] LoaiHang loaiHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loaiHang);
        }

        // GET: LoaiHangs/Delete/5
        public async Task<ActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaiHang loaiHang = await db.LoaiHangs.FindAsync(id);
            db.LoaiHangs.Remove(loaiHang);
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
