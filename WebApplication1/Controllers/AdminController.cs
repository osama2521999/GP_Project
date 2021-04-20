using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {

        private DatabaseEntities1 db = new DatabaseEntities1();

        // GET: Admin
        public ActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctor([Bind(Include = "Doctor_id,Email,Name,Password,Max_team,Last_login")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                //db.Doctor.SqlQuery("INSERT INTO Doctor (Last_login) VALUES('@DateTime.Now') ");
                //db.SaveChanges();
                Doctor doctor1 = new Doctor();
                doctor1.Last_login = DateTime.Now;
                db.Doctor.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Doctor");
            }

            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSponsor([Bind(Include = "Sponsor_id,Email,Name,Password")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                TempData["Result"] = "";
                Sponsor spon = new Sponsor();
                var find = db.Sponsor.FirstOrDefault(son => son.Email == sponsor.Email);
                if (find != null) 
                    {
                    TempData["Result"] = "User Already Exists !!"; 
                    return RedirectToAction("AddSponsor");
                    }
                
                db.Sponsor.Add(sponsor);
                db.SaveChanges();
                return RedirectToAction("Sponsor");
            }

            return View();
        }
        public ActionResult Delete(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            db.Doctor.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Doctor");
        }
        public ActionResult DeleteSponsor(int id) 
        {
            Sponsor sponsor = db.Sponsor.Find(id);
            db.Sponsor.Remove(sponsor);
            db.SaveChanges();
            return RedirectToAction("Sponsor");
        }

        public ActionResult Archive()
        {
            return View();
        }
        public ActionResult Doctor()
        {
            return View(db.Doctor.ToList());
        }
        public ActionResult Sponsor()
        {
            return View(db.Sponsor.ToList());
        }
        public ActionResult AddSponsor()
        {
            return View();
        }
        public ActionResult Student()
        {
            return View();
        }
    }
}