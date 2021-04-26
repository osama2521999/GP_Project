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
        public ActionResult AddDoctor([Bind(Include = "Doctor_id,Email,Name,Password,Max_team,Last_login,Doctor_department")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                //db.Doctor.SqlQuery("INSERT INTO Doctor (Last_login) VALUES('@DateTime.Now') ");
                //db.SaveChanges();
                //Doctor doctor1 = new Doctor();
                //doctor1.Last_login = DateTime.Now;
                //department.Student_id = 0;
                //department.Team_id = 0;
                //db.Department.Add(department);
                db.Doctor.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Doctor");
            }

            return View(doctor);
        }

        public ActionResult Delete(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            db.Doctor.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Doctor");
        }


        public ActionResult Archive()
        {
            return View();
        }
        public ActionResult Doctor()
        {
            return View(db.Doctor.ToList());
        }
        public ActionResult Student()
        {
            return View();
        }
    }
}