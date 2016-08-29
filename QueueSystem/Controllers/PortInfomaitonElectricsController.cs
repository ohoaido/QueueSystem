using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QueueSystem.Models;
using Microsoft.AspNet.Identity;

namespace QueueSystem.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    public class PortInfomaitonElectricsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PortInfomaitonElectrics
        public ActionResult Index()
        {
            return View(db.PortInfomaitonElectrics.ToList());
        }

        // GET: PortInfomaitonElectrics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortInfomaitonElectric portInfomaitonElectric = db.PortInfomaitonElectrics.Find(id);
            if (portInfomaitonElectric == null)
            {
                return HttpNotFound();
            }
            return View(portInfomaitonElectric);
        }

        // GET: PortInfomaitonElectrics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortInfomaitonElectrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Url,Name,Phone,Datecreated,IsPublic")] PortInfomaitonElectric portInfomaitonElectric)
        {
            if (ModelState.IsValid)
            {
                portInfomaitonElectric.Datecreated = DateTime.Now;
                db.PortInfomaitonElectrics.Add(portInfomaitonElectric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portInfomaitonElectric);
        }

        // GET: PortInfomaitonElectrics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortInfomaitonElectric portInfomaitonElectric = db.PortInfomaitonElectrics.Find(id);
            if (portInfomaitonElectric == null)
            {
                return HttpNotFound();
            }
            return View(portInfomaitonElectric);
        }

        // POST: PortInfomaitonElectrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Url,Name,Phone,Datecreated,IsPublic")] PortInfomaitonElectric portInfomaitonElectric)
        {
            if (ModelState.IsValid)
            {
                portInfomaitonElectric.Datecreated = DateTime.Now;
                db.Entry(portInfomaitonElectric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portInfomaitonElectric);
        }

        // GET: PortInfomaitonElectrics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortInfomaitonElectric portInfomaitonElectric = db.PortInfomaitonElectrics.Find(id);
            if (portInfomaitonElectric == null)
            {
                return HttpNotFound();
            }
            return View(portInfomaitonElectric);
        }

        // POST: PortInfomaitonElectrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortInfomaitonElectric portInfomaitonElectric = db.PortInfomaitonElectrics.Find(id);
            db.PortInfomaitonElectrics.Remove(portInfomaitonElectric);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Active()
        {
            return View(db.PortInfomaitonElectrics.Where(i=>!i.IsPublic).ToList());
        }
        public ActionResult Acpactive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortInfomaitonElectric portInfomaitonElectric = db.PortInfomaitonElectrics.Find(id);
            portInfomaitonElectric.IsPublic = true;
            db.Entry(portInfomaitonElectric).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Active");
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
