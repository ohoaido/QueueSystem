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
using Microsoft.AspNet.Identity.EntityFramework;

namespace QueueSystem.Controllers
{
    [Authorize]
    public class ManHinhsController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManHinhs
        public ActionResult Index()
        {
            var roles = db.Roles.Where(p=>p.Users.Select(x=>x.UserId == AccountID).FirstOrDefault());
            Boolean flag = false;
            foreach (var item in roles)
            {
                if(item.Name == "SuperAdmin") {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                return View(db.ManHinhs.ToList());
            }
            else { 
                int PortInfomaitonElectricID = db.Users.Where(user => user.Id == AccountID).Select(p => p.PortInfomaitonElectricID).FirstOrDefault();
                return View(db.ManHinhs.Where(p => p.PortInfomaitonElectric.ID == PortInfomaitonElectricID).ToList());
            }
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
            int PortInfomaitonElectricID = db.Users.Where(user => user.Id == AccountID).Select(p => p.PortInfomaitonElectricID).FirstOrDefault();
            ViewBag.PortInfomaitonElectric = db.PortInfomaitonElectrics.ToList().Where(p=>p.IsPublic && p.ID == PortInfomaitonElectricID);
            return View();
        }

        // POST: ManHinhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ManHinhSo,PortInfomaitonElectricID")] ManHinh manHinh)
        {
            int PortInfomaitonElectricID = db.Users.Where(user => user.Id == AccountID).Select(p => p.PortInfomaitonElectricID).FirstOrDefault();
            ViewBag.PortInfomaitonElectric = db.PortInfomaitonElectrics.ToList().Where(p => p.IsPublic && p.ID == PortInfomaitonElectricID);
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
            int PortInfomaitonElectricID = db.Users.Where(user => user.Id == AccountID).Select(p => p.PortInfomaitonElectricID).FirstOrDefault();
            ViewBag.PortInfomaitonElectric = db.PortInfomaitonElectrics.ToList().Where(p => p.IsPublic && p.ID == PortInfomaitonElectricID);
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
            int PortInfomaitonElectricID = db.Users.Where(user => user.Id == AccountID).Select(p => p.PortInfomaitonElectricID).FirstOrDefault();
            ViewBag.PortInfomaitonElectric = db.PortInfomaitonElectrics.ToList().Where(p => p.IsPublic && p.ID == PortInfomaitonElectricID);
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
