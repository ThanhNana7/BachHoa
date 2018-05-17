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
    public class CuaHangsController : Controller
    {
        private dbBachHoa db = new dbBachHoa();

        // GET: CuaHangs
        public async Task<ActionResult> Index(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.CuaHangs.ToList().OrderBy(n => n.MSCH).ToPagedList(pageNumber, pageSize));
        }

        // GET: CuaHangs/Details/5
        public async Task<ActionResult> Details(int? id)
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
        public ActionResult Create()
        {
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang");
            ViewBag.NvPhuTrach = new SelectList(db.NVPhuTraches, "MSNV", "HoTen");
            return View();
        }

        // POST: CuaHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MSCH,TenCH,MSLH,DiaChi,NvPhuTrach,SDT")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                db.CuaHangs.Add(cuaHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", cuaHang.MSLH);
            ViewBag.NvPhuTrach = new SelectList(db.NVPhuTraches, "MSNV", "HoTen", cuaHang.NvPhuTrach);
            return View(cuaHang);
        }

        // GET: CuaHangs/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MSCH,TenCH,MSLH,DiaChi,NvPhuTrach,SDT")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuaHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MSLH = new SelectList(db.LoaiHangs, "MSLH", "TenLoaiHang", cuaHang.MSLH);
            ViewBag.NvPhuTrach = new SelectList(db.NVPhuTraches, "MSNV", "HoTen", cuaHang.NvPhuTrach);
            return View(cuaHang);
        }

        // GET: CuaHangs/Delete/5
        public async Task<ActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CuaHang cuaHang = await db.CuaHangs.FindAsync(id);
            db.CuaHangs.Remove(cuaHang);
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
