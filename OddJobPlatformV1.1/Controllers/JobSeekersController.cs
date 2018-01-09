using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OddJobPlatformV1._1.Models;

namespace OddJobPlatformV1._1.Controllers
{
    public class JobSeekersController : Controller
    {
        private JobSeekerDBContext db = new JobSeekerDBContext();

        // GET: JobSeekers
        public ActionResult Index()
        {
            return View(db.JobSeekers.ToList());
        }

        // GET: JobSeekers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // GET: JobSeekers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobSeekers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jsId,jsName,gender,dob,address,country,state,postCode,mobile,cv,emailId,password")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
               db.JobSeekers.Add(jobSeeker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobSeeker);
        }

        // GET: JobSeekers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // POST: JobSeekers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jsId,jsName,gender,dob,address,country,state,postCode,mobile,cv,emailId,password")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSeeker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobSeeker);
        }

        // GET: JobSeekers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // POST: JobSeekers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            db.JobSeekers.Remove(jobSeeker);
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
