using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private DatabaseEntities1 db = new DatabaseEntities1();


        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login( Doctor doctor ,String subject, String Email, String Password)
        {
            if (ModelState.IsValid)
            {

                if (subject == "Doctor")
                {

                    var doc = db.Doctor.Where(x => x.Email == doctor.Email && x.Password == doctor.Password);


                    if (doc.Count() == 1)
                    {
                        //var id = db.Database.SqlQuery<Doctor>("Select Doctor_id from dbo.Doctor where Email=@Email , Password=@Password",doctor.Email,doctor.Password);
                        return RedirectToAction("MyProfile", "Doctor",new { id=doc.First().Doctor_id });
                    }
                    else
                    {
                        return HttpNotFound();
                    }

                }else if (subject == "Admin")
                {
                    if(Email=="admin@admin" && Password == "admin")
                    {
                        return RedirectToAction("AddDoctor", "Admin");
                    }

                }
                else
                {
                    return View(doctor);
                }
                
            }
            return View(doctor);
        }
        public ActionResult Done()
        {
            return View();
        }
    }
}