using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QueueSystem.Models;
using AutoMapper;
using Microsoft.AspNet.SignalR.StockTicker;

namespace QueueSystem.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class HeThongSosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HeThongSoes
        public ActionResult Index()
        {
            return View(db.HeThongSos.ToList().OrderBy(o=>o.ManHinhID));
        }

        // GET: HeThongSoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeThongSo heThongSo = db.HeThongSos.Find(id);
            if (heThongSo == null)
            {
                return HttpNotFound();
            }
            return View(heThongSo);
        }

        // GET: HeThongSoes/Create
        public ActionResult Create()
        {
            ViewBag.ManHinh = db.ManHinhs.ToList();
            return View();
        }

        // POST: HeThongSoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,STT,Goi,DateCreated,ManHinhID")] HeThongSo heThongSo)
        {
            ViewBag.ManHinh = db.ManHinhs.ToList();
            if (ModelState.IsValid)
            {
                int lastid = db.HeThongSos.Where(x=>x.ManHinhID == heThongSo.ManHinhID).Count();
                lastid = lastid + 1;
                heThongSo.STT = lastid;
                heThongSo.DateCreated = DateTime.Now;
                heThongSo.Timers = DateTime.Now;
                heThongSo.STTConfirmed = true;
                db.HeThongSos.Add(heThongSo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heThongSo);
        }

        // GET: HeThongSoes/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ManHinh = db.ManHinhs.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeThongSo heThongSo = db.HeThongSos.Find(id);
            if (heThongSo == null)
            {
                return HttpNotFound();
            }
            return View(heThongSo);
        }

        // POST: HeThongSoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,STT,Goi,DateCreated,ManHinhID")] HeThongSo heThongSo)
        {
            ViewBag.ManHinh = db.ManHinhs.ToList();
            if (ModelState.IsValid)
            {
                db.Entry(heThongSo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heThongSo);
        }

        // GET: HeThongSoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeThongSo heThongSo = db.HeThongSos.Find(id);
            if (heThongSo == null)
            {
                return HttpNotFound();
            }
            return View(heThongSo);
        }

        // POST: HeThongSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeThongSo heThongSo = db.HeThongSos.Find(id);
            db.HeThongSos.Remove(heThongSo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Show(int id)
        {
            HeThongSoViewModels hs = new HeThongSoViewModels();
            hs.ManHinhID = id;
            var xp = Mapper.Map<HeThongSoViewModels, HeThongSo>(hs);
            HeThongSo heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID && !x.Goi).OrderBy(x => x.STT).FirstOrDefault();
            if (heThongSo == null)
            {
                heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID).OrderByDescending(x => x.STT).FirstOrDefault();
            }
            return Json(heThongSo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowSo(int id)
        {
            HeThongSoViewModels hs = new HeThongSoViewModels();
            hs.ManHinhID = id;
            var xp = Mapper.Map<HeThongSoViewModels, HeThongSo>(hs);
            HeThongSo heThongSo = db.HeThongSos.Where(x=>x.ManHinhID == xp.ManHinhID && !x.Goi).OrderBy(x => x.STT).FirstOrDefault();
            if (heThongSo == null)
            {
                heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID).OrderByDescending(x => x.STT).FirstOrDefault();
            }
            else
            {
                heThongSo.Goi = true;
                db.Entry(heThongSo).State = EntityState.Modified;
                db.SaveChanges();
                heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID && !x.Goi).OrderBy(x => x.STT).FirstOrDefault();
            }
            if (heThongSo == null)
            {
                heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID).OrderByDescending(x => x.STT).FirstOrDefault();
            }
            return Json(heThongSo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAll()
        {
            List<HeThongSo> heThongSo = db.HeThongSos.ToList();
            var str = "";
            foreach (var item in heThongSo)
            {
                if ((DateTime.Now >= item.Timers) || !item.STTConfirmed) {
                    db.HeThongSos.Remove(item);
                }
                else
                {
                    str = "Timers";
                }
            }
            db.SaveChanges();
            if (str == "Timers")
            {
                return Json("Timers", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("OK", JsonRequestBehavior.AllowGet);
        }

        // GET: HeThongSoes/Details/5
        public ActionResult ViewDetails(int id)
        {
            HeThongSoViewModels hs = new HeThongSoViewModels();
            hs.ManHinhID = id;
            var xp = Mapper.Map<HeThongSoViewModels, HeThongSo>(hs);
            HeThongSo heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID && !x.Goi).OrderBy(x => x.STT).FirstOrDefault();
            if (heThongSo == null)
            {
                heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID).OrderByDescending(x => x.STT).FirstOrDefault();
            }
            return View(heThongSo);
        }

        public JsonResult TimersS(int id)
        {
            HeThongSoViewModels hs = new HeThongSoViewModels();
            hs.ManHinhID = id;
            var xp = Mapper.Map<HeThongSoViewModels, HeThongSo>(hs);
            HeThongSo heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID && !x.Goi).OrderBy(x => x.STT).FirstOrDefault();
            if (heThongSo == null)
            {
                heThongSo = db.HeThongSos.Where(x => x.ManHinhID == xp.ManHinhID).OrderByDescending(x => x.STT).FirstOrDefault();
            }
            var STT = heThongSo.STT;
            return Json(STT, JsonRequestBehavior.AllowGet);
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
