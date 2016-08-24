using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QueueSystem.Models;

namespace QueueSystem.Controllers
{
    public class PortInfomaitonElectricsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PortInfomaitonElectrics
        public async Task<ActionResult> Index()
        {
            return View(await db.PortInfomaitonElectrics.ToListAsync());
        }

        // GET: PortInfomaitonElectrics/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortInfomaitonElectric portInfomaitonElectric = await db.PortInfomaitonElectrics.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "ID,Url,Name,Phone,IsPublic")] PortInfomaitonElectric portInfomaitonElectric)
        {
            if (ModelState.IsValid)
            {
                portInfomaitonElectric.Datecreated = DateTime.Now;
                db.PortInfomaitonElectrics.Add(portInfomaitonElectric);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(portInfomaitonElectric);
        }

        // GET: PortInfomaitonElectrics/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortInfomaitonElectric portInfomaitonElectric = await db.PortInfomaitonElectrics.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "ID,Url,Name,Phone,Datecreated,IsPublic")] PortInfomaitonElectric portInfomaitonElectric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portInfomaitonElectric).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(portInfomaitonElectric);
        }

        // GET: PortInfomaitonElectrics/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortInfomaitonElectric portInfomaitonElectric = await db.PortInfomaitonElectrics.FindAsync(id);
            if (portInfomaitonElectric == null)
            {
                return HttpNotFound();
            }
            return View(portInfomaitonElectric);
        }

        // POST: PortInfomaitonElectrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PortInfomaitonElectric portInfomaitonElectric = await db.PortInfomaitonElectrics.FindAsync(id);
            db.PortInfomaitonElectrics.Remove(portInfomaitonElectric);
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
