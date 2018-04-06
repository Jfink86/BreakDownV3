using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BreakDownV3;

namespace BreakDownV3.Controllers
{
    public class TuneUpsController : Controller
    {
        private BreakDownV3Entities db = new BreakDownV3Entities();

        // GET: TuneUps
        public ActionResult Index()
        {
            var tuneUps = db.TuneUps.Include(t => t.Vehicle);
            return View(tuneUps.ToList());
        }

        // GET: TuneUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuneUp tuneUp = db.TuneUps.Find(id);
            if (tuneUp == null)
            {
                return HttpNotFound();
            }
            return View(tuneUp);
        }

        // GET: TuneUps/Create
        public ActionResult Create()
        {
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID");
            return View();
        }

        // POST: TuneUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TuneUpID,VehicleID,PlugsChanged,BeltCondition,TireCondition,ODOServiced,NextODO,Notes,Photo,DateTime")] TuneUp tuneUp)
        {
            if (ModelState.IsValid)
            {
                db.TuneUps.Add(tuneUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", tuneUp.VehicleID);
            return View(tuneUp);
        }

        // GET: TuneUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuneUp tuneUp = db.TuneUps.Find(id);
            if (tuneUp == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", tuneUp.VehicleID);
            return View(tuneUp);
        }

        // POST: TuneUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TuneUpID,VehicleID,PlugsChanged,BeltCondition,TireCondition,ODOServiced,NextODO,Notes,Photo,DateTime")] TuneUp tuneUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuneUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", tuneUp.VehicleID);
            return View(tuneUp);
        }

        // GET: TuneUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuneUp tuneUp = db.TuneUps.Find(id);
            if (tuneUp == null)
            {
                return HttpNotFound();
            }
            return View(tuneUp);
        }

        // POST: TuneUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TuneUp tuneUp = db.TuneUps.Find(id);
            db.TuneUps.Remove(tuneUp);
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
