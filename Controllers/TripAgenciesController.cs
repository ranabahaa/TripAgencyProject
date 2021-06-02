using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TripAgencyProject.Models;
using System.IO;

namespace TripAgencyProject.Controllers
{
    public class TripAgenciesController : Controller
    {
        private ProjectDBEntities2 db = new ProjectDBEntities2();

        // GET: TripAgencies
        public ActionResult Index()
        {
            var tripAgencies = db.TripAgencies.Include(t => t.Admin);
            return View(tripAgencies.ToList());
        }

        // GET: TripAgencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripAgency tripAgency = db.TripAgencies.Find(id);
            if (tripAgency == null)
            {
                return HttpNotFound();
            }
            return View(tripAgency);
        }

        // GET: TripAgencies/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "Id", "Username");
            return View();
        }

        // POST: TripAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Email,Password,PhoneNo,Photo,UserRole,AdminID")] TripAgency tripAgency , HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                string path = "";
                if (imgFile.FileName.Length > 0)
                {

                    path = "~/images/" + Path.GetFileName(imgFile.FileName);
                    imgFile.SaveAs(Server.MapPath(path));

                }

                tripAgency.Photo = path;


                db.TripAgencies.Add(tripAgency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminID = new SelectList(db.Admins, "Id", "Username", tripAgency.AdminID);
            return View(tripAgency);
        }

        // GET: TripAgencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripAgency tripAgency = db.TripAgencies.Find(id);
            if (tripAgency == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.Admins, "Id", "Username", tripAgency.AdminID);
            return View(tripAgency);
        }

        // POST: TripAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Email,Password,PhoneNo,Photo,UserRole,AdminID")] TripAgency tripAgency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tripAgency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminID = new SelectList(db.Admins, "Id", "Username", tripAgency.AdminID);
            return View(tripAgency);
        }

        // GET: TripAgencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripAgency tripAgency = db.TripAgencies.Find(id);
            if (tripAgency == null)
            {
                return HttpNotFound();
            }
            return View(tripAgency);
        }

        // POST: TripAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TripAgency tripAgency = db.TripAgencies.Find(id);
            db.TripAgencies.Remove(tripAgency);
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
