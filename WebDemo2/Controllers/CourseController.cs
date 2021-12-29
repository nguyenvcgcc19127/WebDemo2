using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class CourseController : Controller
    {
        Training db = new Training();
        // GET: Course
        public ActionResult Index()
        {
            var list = db.Courses.ToList<Course>();
            return View(list);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Course_ID, Course_Name, Course_Category, Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Course Course = db.Courses.Find(id);

            return View(Course);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Course_ID, Course_Name, Course_Category, Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {

            Course course = db.Courses.Find(id);

            db.Courses.Remove(course);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}