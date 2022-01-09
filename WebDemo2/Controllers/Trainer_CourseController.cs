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
        // GET: Trainer_Course

        // Index() to display list of Trainer Course
        public ActionResult Index()
        {
            var list = db.Trainer_Course.ToList<Trainer_Course>();
            return View(list);
        }

        // When the user clicks the Create button on the Trainer Course page, the system will point to the Create() function (HttpGet method) of Trainer_CourseController.
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // When the user clicks the Create button on the Create Trainer Course page, the system will point to the Create() function (HttpPost method) of the Trainer_CourseController
        [HttpPost]
        public ActionResult Create([Bind(Include = "No, Course_ID, Trainer_ID, Trainer_Name")] Trainer_Course trainer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Trainer_Course.Add(trainer);
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

        // When the user clicks the Edit button on the Trainer Course page, the system will point to the Edit() function (HttpGet method) of Trainer_CourseController.

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Trainer_Course trainer = db.Trainer_Course.Find(id);

            return View(trainer);
        }

        // When the user clicks the Edit button on the Trainer Coursec page, the system will point to the Edit() function (HttpPost method) of Trainer_CourseController.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "No, Course_ID, Trainer_ID, Trainer_Name")] Trainer_Course trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        //When the user clicks the Delete button on the Trainer Course page, a confirmation alert will be displayed
        [HttpGet]
        public ActionResult Delete(string id)
        {

            Trainer_Course trainer = db.Trainer_Course.Find(id);

            db.Trainer_Course.Remove(trainer);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}