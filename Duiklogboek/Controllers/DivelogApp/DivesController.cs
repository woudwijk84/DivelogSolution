using Duiklogboek.Models;
using Duiklogboek.Models.DivelogApp;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Duiklogboek.Controllers.DivelogApp
{
    public class DivesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private const string diveWhiteList = "DiveId,Location,DiveSite,Date,Duration,Weather,Visibility,Notes,Buddy,Username,DiveNumber";

        // GET: Dives/username
        public ActionResult Index(string username)
        {
            //string userId = User.Identity.GetUserId();
            var dives = db.Dives.Where(a => a.Username == username);
            return View(dives.ToList());
        }

        // GET: Dives/Details/username/5
        public ActionResult Details(string username, int? divenumber)
        {
            if (divenumber == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = GetCurrentUser(username);
                Dive dive = null;

            dive = user.Dives.Where(a => a.DiveNumber == divenumber).Single();

            if (dive == null)
            {
                return HttpNotFound();
            }
            return View(dive);
        }

        // GET: Dives/Create/username
        public ActionResult Create(string username)
        {
            ViewBag.diveNumber = GetNextDiveNumber(username);
            return View();
        }

        // POST: Dives/Create/username
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string username, [Bind(Include = diveWhiteList)] Dive dive)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(username))
                {
                    username = User.Identity.GetUserName();
                    dive.Username = username;
                }

                dive.DiveNumber = GetNextDiveNumber(username);

                ApplicationUser user = GetCurrentUser(username);
                if (user != default(ApplicationUser))
                {
                    user.Dives.Add(dive);
                }
                db.Dives.Add(dive);
                db.SaveChanges();
                return RedirectToAction("Index", "Dives", new { username = username });
            }

            return View(dive);
        }

        // GET: Dives/Edit/username/5
        public ActionResult Edit(string username, int? divenumber)
        {
            if (divenumber == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Dive dive = db.Dives.Find(id);
            ApplicationUser user = GetCurrentUser(username);
            Dive dive = null;

            dive = user.Dives.Where(a => a.DiveNumber == divenumber).Single();

            if (dive == null)
            {
                return HttpNotFound();
            }
            return View(dive);
        }

        // POST: Dives/Edit/username/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string username, [Bind(Include = diveWhiteList)] Dive dive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Dives", new { username = username });
            }
            return View(dive);
        }

        // GET: Dives/Delete/username/5
        public ActionResult Delete(string username, int? divenumber)
        {
            if (divenumber == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Dive dive = db.Dives.Find(divenumber);
            ApplicationUser user = GetCurrentUser(username);
            Dive dive = null;

            dive = user.Dives.Where(a => a.DiveNumber == divenumber).Single();

            if (dive == null)
            {
                return HttpNotFound();
            }
            return View(dive);
        }

        // POST: Dives/Delete/username/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string username, int divenumber)
        {
            //Dive dive = db.Dives.Find(id);
            ApplicationUser user = GetCurrentUser(username);
            Dive dive = null;

            dive = user.Dives.Where(a => a.DiveNumber == divenumber).Single();

            db.Dives.Remove(dive);
            db.SaveChanges();
            return RedirectToAction("Index", "Dives", new { username = username });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [ChildActionOnly]
        public PartialViewResult GetLatestDive()
        {
            string username = User.Identity.GetUserName();
            Dive latestDive = db.Dives.Where(a => a.Username == username).OrderByDescending(b => b.Date).FirstOrDefault();

            return PartialView("DivelogApp/_Dive", latestDive);
        }

        private Int32 GetNextDiveNumber(string username)
        {
            Int32 nextDiveNumber = 1;

            Int32 lastDiveNumber = db.Dives.Where(a => a.Username == username)
                                .OrderByDescending(a => a.DiveNumber)
                                .Select(a => a.DiveNumber)
                                .FirstOrDefault();
            if (lastDiveNumber != 0)
            {
                nextDiveNumber = lastDiveNumber++;
            }

            return nextDiveNumber;
        }

        private ApplicationUser GetCurrentUser(string username)
        {
            var store = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByName(username);
            return user;
        }
    }
}
