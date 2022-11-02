using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_CNPM.Models;

namespace BTL_CNPM.Controllers
{
    public class ThietBiController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: ThietBi
        public ActionResult Index()
        {
            var thietBis = db.ThietBis.Include(t => t.NhaCungCap).Include(t => t.Phong).Include(t => t.TrangThaiTB);
            return View(thietBis.ToList());
        }

        // GET: ThietBi/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThietBi thietBi = db.ThietBis.Find(id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }
            return View(thietBi);
        }

        // GET: ThietBi/Create
        public ActionResult Create()
        {
            ViewBag.IdNhaCungCap = new SelectList(db.NhaCungCaps, "Id", "Ten");
            ViewBag.IdPhong = new SelectList(db.Phongs, "Id", "TenPhong");
            ViewBag.IdTrangThai = new SelectList(db.TrangThaiTBs, "Id", "TenTrangThai");
            return View();
        }

        // POST: ThietBi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ten,SoSerial,IdNhaCungCap,SoNamBaoHanh,NgayMua,IdTrangThai,IdPhong")] ThietBi thietBi)
        {
            if (ModelState.IsValid)
            {
                db.ThietBis.Add(thietBi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdNhaCungCap = new SelectList(db.NhaCungCaps, "Id", "Ten", thietBi.IdNhaCungCap);
            ViewBag.IdPhong = new SelectList(db.Phongs, "Id", "TenPhong", thietBi.IdPhong);
            ViewBag.IdTrangThai = new SelectList(db.TrangThaiTBs, "Id", "TenTrangThai", thietBi.IdTrangThai);
            return View(thietBi);
        }

        // GET: ThietBi/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThietBi thietBi = db.ThietBis.Find(id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNhaCungCap = new SelectList(db.NhaCungCaps, "Id", "Ten", thietBi.IdNhaCungCap);
            ViewBag.IdPhong = new SelectList(db.Phongs, "Id", "TenPhong", thietBi.IdPhong);
            ViewBag.IdTrangThai = new SelectList(db.TrangThaiTBs, "Id", "TenTrangThai", thietBi.IdTrangThai);
            return View(thietBi);
        }

        // POST: ThietBi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ten,SoSerial,IdNhaCungCap,SoNamBaoHanh,NgayMua,IdTrangThai,IdPhong")] ThietBi thietBi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thietBi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdNhaCungCap = new SelectList(db.NhaCungCaps, "Id", "Ten", thietBi.IdNhaCungCap);
            ViewBag.IdPhong = new SelectList(db.Phongs, "Id", "TenPhong", thietBi.IdPhong);
            ViewBag.IdTrangThai = new SelectList(db.TrangThaiTBs, "Id", "TenTrangThai", thietBi.IdTrangThai);
            return View(thietBi);
        }

        // GET: ThietBi/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThietBi thietBi = db.ThietBis.Find(id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }
            return View(thietBi);
        }

        // POST: ThietBi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ThietBi thietBi = db.ThietBis.Find(id);
            db.ThietBis.Remove(thietBi);
            db.SaveChanges();
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
