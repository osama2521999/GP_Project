using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SponsorsController : Controller
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // GET: Sponsors
        public ActionResult Index()
        {
            return View(db.Sponsor.ToList());
        }

        // GET: Sponsors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsor.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // GET: Sponsors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sponsors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SponsorLogin([Bind(Include = "Email,Password")] Sponsor sponsor)
        {
            TempData["LoginResult"] = "";
            var s = db.Sponsor.Where(x=> x.Email == sponsor.Email && x.Password ==sponsor.Password).ToList().FirstOrDefault();
            if (s != null) 
            { 
                    TempData["LoginResult"] = "grant";
                    TempData["session_id"] = s.Sponsor_id;
                    return RedirectToAction("SponsorHome",s);
            }
            TempData["LoginResult"] = "Something Went Wrong";
            return View("SponsorLogin");
        }
        public ActionResult SponsorHome()//Sponsor sponsor) 
        {
            //Debug Purposes (retrieve the first sponsor in the Database)
            var sponsor = db.Sponsor.Where(x => x.Email == "osama").ToList().FirstOrDefault();
            //Delete this region when debugging ends
            return View("SponsorHome", sponsor);
        }
        public ActionResult SponsorLogin()
        {
            TempData["debug"] = "initialized";
            TempData["LoginResult"] = "Sponsor Login";
            return View("SponsorLogin");
        }
        // GET: Sponsors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsor.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sponsor_id,Email,Name,Password")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sponsor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsor);
        }

        // GET: Sponsors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsor.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sponsor sponsor = db.Sponsor.Find(id);
            db.Sponsor.Remove(sponsor);
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
