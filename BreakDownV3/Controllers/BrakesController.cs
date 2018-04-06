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
    public class BrakesController : Controller
    {
        private BreakDownV3Entities db = new BreakDownV3Entities();

        // GET: Brakes
        public ActionResult Index()
        {
            var brakes = db.Brakes.Include(b => b.Vehicle);
            return View(brakes.ToList());
        }

        // GET: Brakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brake brake = db.Brakes.Find(id);
            if (brake == null)
            {
                return HttpNotFound();
            }
            return View(brake);
        }

        // GET: Brakes/Create
        public ActionResult Create()
        {
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID");
            return View();
        }

        // POST: Brakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrakesID,VehicleID,FrontBool,RearBool,ODOServiced,NextODO,Notes,Photo,DateTime")] Brake brake)
        {
            if (ModelState.IsValid)
            {
                db.Brakes.Add(brake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", brake.VehicleID);
            return View(brake);
        }

        // GET: Brakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brake brake = db.Brakes.Find(id);
            if (brake == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", brake.VehicleID);
            return View(brake);
        }

        // POST: Brakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrakesID,VehicleID,FrontBool,RearBool,ODOServiced,NextODO,Notes,Photo,DateTime")] Brake brake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", brake.VehicleID);
            return View(brake);
        }

        // GET: Brakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brake brake = db.Brakes.Find(id);
            if (brake == null)
            {
                return HttpNotFound();
            }
            return View(brake);
        }

        // POST: Brakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brake brake = db.Brakes.Find(id);
            db.Brakes.Remove(brake);
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
