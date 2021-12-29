using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class TraineeController : Controller
    {
        Training db = new Training();
        // GET: Trainee
        public ActionResult Index()
        {
            var list = db.Trainees.ToList<Trainee>();
            return View(list);
        }

        

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")] Trainee trainee)
        {
            Trainee acc = new Trainee();
            acc = db.Trainees.Where(p => p.Email == trainee.Email && p.Password == p.Password).FirstOrDefault();
            if (acc != null)
            {
                Session["Email"] = acc.Email;
                return RedirectToAction("index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Trainee_ID, Trainee_Name, Email, Age, Date_of_Birth, Education, Password")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Trainee trainee = db.Trainees.Find(id);

            return View(trainee);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Trainee_ID, Trainee_Name, Email, Age, Date_of_Birth, Education, Password")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {

            Trainee trainee = db.Trainees.Find(id);

            db.Trainees.Remove(trainee);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}