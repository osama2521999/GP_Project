using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class DoctorController : Controller
    {

        private DatabaseEntities1 db = new DatabaseEntities1();

        // GET: Doctor
        

        public ActionResult MyProfile(int id)
        {
            Doctor doctor = db.Doctor.Find(id);

            ViewBag.doctor_id = id;
            ViewBag.doctor_Email = doctor.Email;
            ViewBag.doctor_Name = doctor.Name;
            ViewBag.doctor_Password = doctor.Password;
            ViewBag.doctor_Max_team = doctor.Max_team;
            ViewBag.Doctor_department = doctor.Doctor_department;

            return View();
        }

        //[HttpPost]
        //public ActionResult Edite(int id)
        //{
        //    return View();
        //}

        //public ActionResult Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Doctor doctor = db.Doctor.Find(id);
        //    if (doctor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        public ActionResult Edit(int id)
        {
            Doctor doctor = db.Doctor.Find(id);

            ViewBag.doctor_id = id;
            ViewBag.doctor_Email = doctor.Email;
            ViewBag.doctor_Name = doctor.Name;
            ViewBag.doctor_Password = doctor.Password;
            ViewBag.doctor_Max_team = doctor.Max_team;
            ViewBag.Doctor_department = doctor.Doctor_department;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Doctor_id,Email,Name,Password,Max_team,Last_login,Doctor_department")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyProfile", "Doctor", new { id = doctor.Doctor_id });
            }
            return View(doctor);
        }
    }
}