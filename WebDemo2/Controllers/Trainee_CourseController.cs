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
            var list = db.Trainee_Course.ToList<Trainee_Course>();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "No, Course_ID, Trainee_ID, Trainee_Name")] Trainee_Course trainee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Trainee_Course.Add(trainee);
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
            Trainee_Course trainee = db.Trainee_Course.Find(id);

            return View(trainee);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "No, Course_ID, Trainee_ID, Trainee_Name")] Trainee_Course trainee)
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

            Trainee_Course trainee = db.Trainee_Course.Find(id);

            db.Trainee_Course.Remove(trainee);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}