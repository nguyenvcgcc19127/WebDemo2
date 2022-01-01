using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class TrainerController : Controller
    {
        Training db = new Training();
        // GET: Trainer
        public ActionResult Index()
        {
            var list = db.Trainers.ToList<Trainer>();
            return View(list);
        }

        

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult ViewProfile()
        {
            
            return View();
        }

        public ActionResult EditViewProfile(string id)
        {
            Trainer trainer = db.Trainers.Find(id);
/*            if (trainer != null)*/
                return View(trainer);
/*            else
                return RedirectToAction("Index", "Home");*/
        }


        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")] Trainer trainer)
        {
            Trainer acc = new Trainer();
            acc = db.Trainers.Where(p => p.Email == trainer.Email && p.Password == p.Password).FirstOrDefault();
            if (acc != null)
            {
                Session["Email"] = acc.Email;
                return RedirectToAction("Index", "Home");
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
        public ActionResult Create([Bind(Include = "Trainer_ID, Trainer_Name, Email, Specialty, Age, Address, Password")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Trainer trainer = db.Trainers.Find(id);

            return View(trainer);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Trainer_ID, Trainer_Name, Email, Specialty, Age, Address, Password")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {

            Trainer trainer = db.Trainers.Find(id);

            db.Trainers.Remove(trainer);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}