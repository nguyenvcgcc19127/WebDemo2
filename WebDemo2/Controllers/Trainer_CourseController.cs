using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;
using System.Data;
using System.Data.Entity;

namespace WebDemo2.Controllers
{

    public class Trainer_CourseController : Controller
    {
        Training db = new Training();
        // GET: Trainer
        public ActionResult Index()
        {
            var list = db.Trainers.ToList<Trainer>();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "No, Course_ID, Trainer_ID, Trainer_Name")] Trainer trainer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Trainers.Add(trainer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Duplicate No!");
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
        public ActionResult Edit([Bind(Include = "No, Course_ID, Trainer_ID, Trainer_Name")] Trainer trainer)
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