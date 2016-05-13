using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Duiklogboek.Models;
using Duiklogboek.Models.DivelogApp;

namespace Duiklogboek.Controllers.DivelogApp
{
    public class CertificatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Certificates
        public ActionResult Index(string userName)
        {
            var certificates = db.Certificates.Where(a => a.Username == userName);
            return View(certificates.ToList());
        }

        // GET: Certificates/Details/5
        public ActionResult Details(string userName, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }

        // GET: Certificates/Create
        public ActionResult Create(string username)
        {
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string username, [Bind(Include = "CertificateId,DivingOrganisation")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                db.Certificates.Add(certificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(certificate);
        }

        // GET: Certificates/Edit/5
        public ActionResult Edit(string username, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string username, [Bind(Include = "CertificateId,DivingOrganisation")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(certificate);
        }

        // GET: Certificates/Delete/5
        public ActionResult Delete(string username, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string username, int id)
        {
            Certificate certificate = db.Certificates.Find(id);
            db.Certificates.Remove(certificate);
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
