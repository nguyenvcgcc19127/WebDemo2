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

    public class Trainee_CourseController : Controller
    {
        Training db = new Training();
        // GET: Trainee
        public ActionResult Index()
        {
            var list = db.Trainees.ToList<Trainee>();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "No, Course_ID, Trainee_ID, Trainee_Name")] Trainee trainee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Trainees.Add(trainee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Duplicate No!");
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
        public ActionResult Edit([Bind(Include = "No, Course_ID, Trainee_ID, Trainee_Name")] Trainee trainee)
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