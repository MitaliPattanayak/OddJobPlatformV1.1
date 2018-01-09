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
    public class JobProvidersController : Controller
    {
        private JobProviderDBContext db = new JobProviderDBContext();

        // GET: JobProviders
        public ActionResult Index()
        {
            return View(db.JobProviders.ToList());
        }

        // GET: JobProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProvider jobProvider = db.JobProviders.Find(id);
            if (jobProvider == null)
            {
                return HttpNotFound();
            }
            return View(jobProvider);
        }

        // GET: JobProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jpID,jobName,userName,password,address,email,contactNum")] JobProvider jobProvider)
        {
            if (ModelState.IsValid)
            {
                db.JobProviders.Add(jobProvider);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(jobProvider);
        }



        // GET: JobProviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProvider jobProvider = db.JobProviders.Find(id);
            if (jobProvider == null)
            {
                return HttpNotFound();
            }
            return View(jobProvider);
        }

        // POST: JobProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jpID,jobName,userName,password,address,email,contactNum")] JobProvider jobProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobProvider);
        }

        // GET: JobProviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProvider jobProvider = db.JobProviders.Find(id);
            if (jobProvider == null)
            {
                return HttpNotFound();
            }
            return View(jobProvider);
        }

        // POST: JobProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobProvider jobProvider = db.JobProviders.Find(id);
            db.JobProviders.Remove(jobProvider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: JobProviders/Create
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(JobProvider jp)
        {
            using (JobProviderDBContext db = new JobProviderDBContext())
            {
                var cl = db.JobProviders.Single(c => c.email == jp.email && c.password == jp.password);

                if (cl != null)
                {
                    Session["JPId"] = cl.jpID.ToString();
                    Session["jpEmail"] = cl.email.ToString();
                    //Session["jpName"] = cl.jpName.ToString();
                    return RedirectToAction("Index","Jobs");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong");
                }
            }
            return View();
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
