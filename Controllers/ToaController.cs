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
    public class ToaController : BaseController
    {
        private DBEntities db = new DBEntities();

        // GET: Toa
        public ActionResult Index()
        {
            return View(db.Toas.ToList());
        }

        // GET: Toa/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toa toa = db.Toas.Find(id);
            if (toa == null)
            {
                return HttpNotFound();
            }
            return View(toa);
        }

        // GET: Toa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Toa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenToa")] Toa toa)
        {
            if (ModelState.IsValid)
            {
                db.Toas.Add(toa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toa);
        }

        // GET: Toa/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toa toa = db.Toas.Find(id);
            if (toa == null)
            {
                return HttpNotFound();
            }
            return View(toa);
        }

        // POST: Toa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenToa")] Toa toa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toa);
        }

        // GET: Toa/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toa toa = db.Toas.Find(id);
            if (toa == null)
            {
                return HttpNotFound();
            }
            return View(toa);
        }

        // POST: Toa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Toa toa = db.Toas.Find(id);
            db.Toas.Remove(toa);
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
