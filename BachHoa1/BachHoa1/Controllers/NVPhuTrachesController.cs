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
    public class NVPhuTrachesController : Controller
    {
        private dbBachHoa db = new dbBachHoa();

        // GET: NVPhuTraches
        public async Task<ActionResult> Index(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.NVPhuTraches.ToList().OrderBy(n => n.MSNV).ToPagedList(pageNumber, pageSize));
        }

        // GET: NVPhuTraches/Details/5
        public async Task<ActionResult> Details(int? id)
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: NVPhuTraches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MSNV,HoTen,Phai,NamSinh,DiaChi,SDT,TaiKhoan,MatKhau")] NVPhuTrach nVPhuTrach)
        {
            if (ModelState.IsValid)
            {
                db.NVPhuTraches.Add(nVPhuTrach);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nVPhuTrach);
        }

        // GET: NVPhuTraches/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MSNV,HoTen,Phai,NamSinh,DiaChi,SDT,TaiKhoan,MatKhau")] NVPhuTrach nVPhuTrach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nVPhuTrach).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nVPhuTrach);
        }

        // GET: NVPhuTraches/Delete/5
        public async Task<ActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NVPhuTrach nVPhuTrach = await db.NVPhuTraches.FindAsync(id);
            db.NVPhuTraches.Remove(nVPhuTrach);
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
