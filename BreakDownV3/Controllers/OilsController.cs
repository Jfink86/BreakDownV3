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
    public class OilsController : Controller
    {
        private BreakDownV3Entities db = new BreakDownV3Entities();

        // GET: Oils
        public ActionResult Index()
        {
            var oils = db.Oils.Include(o => o.OilType1).Include(o => o.Vehicle);
            return View(oils.ToList());
        }

        // GET: Oils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oil oil = db.Oils.Find(id);
            if (oil == null)
            {
                return HttpNotFound();
            }
            return View(oil);
        }

        // GET: Oils/Create
        public ActionResult Create()
        {
            ViewBag.OilType = new SelectList(db.OilTypes, "OilTypeID", "OilTypeName");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID");
            return View();
        }

        // POST: Oils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OilID,VehicleID,ODOService,OilType,NextODO,Notes,datetime,Photo")] Oil oil)
        {
            if (ModelState.IsValid)
            {
                db.Oils.Add(oil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OilType = new SelectList(db.OilTypes, "OilTypeID", "OilTypeName", oil.OilType);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", oil.VehicleID);
            return View(oil);
        }

        // GET: Oils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oil oil = db.Oils.Find(id);
            if (oil == null)
            {
                return HttpNotFound();
            }
            ViewBag.OilType = new SelectList(db.OilTypes, "OilTypeID", "OilTypeName", oil.OilType);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", oil.VehicleID);
            return View(oil);
        }

        // POST: Oils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OilID,VehicleID,ODOService,OilType,NextODO,Notes,datetime,Photo")] Oil oil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OilType = new SelectList(db.OilTypes, "OilTypeID", "OilTypeName", oil.OilType);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "VehicleID", oil.VehicleID);
            return View(oil);
        }

        // GET: Oils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oil oil = db.Oils.Find(id);
            if (oil == null)
            {
                return HttpNotFound();
            }
            return View(oil);
        }

        // POST: Oils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oil oil = db.Oils.Find(id);
            db.Oils.Remove(oil);
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
