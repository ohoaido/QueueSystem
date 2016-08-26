using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QueueSystem.Models;

namespace QueueSystem.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ManHinhsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManHinhs
        public ActionResult Index()
        {
            return View(db.ManHinhs.ToList());
        }

        // GET: ManHinhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManHinh manHinh = db.ManHinhs.Find(id);
            if (manHinh == null)
            {
                return HttpNotFound();
            }
            return View(manHinh);
        }

        // GET: ManHinhs/Create
        public ActionResult Create()
        {
            ViewBag.PortInfomaitonElectric = db.PortInfomaitonElectrics.ToList().Where(p=>p.IsPublic);
            return View();
        }

        // POST: ManHinhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ManHinhSo,PortInfomaitonElectricID")] ManHinh manHinh)
        {
            ViewBag.PortInfomaitonElectric = db.PortInfomaitonElectrics.ToList();
            if (ModelState.IsValid)
            {
                db.ManHinhs.Add(manHinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manHinh);
        }

        // GET: ManHinhs/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.PortInfomaitonElectric = db.PortInfomaitonElectrics.ToList().Where(p => p.IsPublic);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManHinh manHinh = db.ManHinhs.Find(id);
            if (manHinh == null)
            {
                return HttpNotFound();
            }
            return View(manHinh);
        }

        // POST: ManHinhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ManHinhSo,PortInfomaitonElectricID")] ManHinh manHinh)
        {
            ViewBag.PortInfomaitonElectric = db.PortInfomaitonElectrics.ToList().Where(p => p.IsPublic);
            if (ModelState.IsValid)
            {
                db.Entry(manHinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manHinh);
        }

        // GET: ManHinhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManHinh manHinh = db.ManHinhs.Find(id);
            if (manHinh == null)
            {
                return HttpNotFound();
            }
            return View(manHinh);
        }

        // POST: ManHinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManHinh manHinh = db.ManHinhs.Find(id);
            db.ManHinhs.Remove(manHinh);
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
