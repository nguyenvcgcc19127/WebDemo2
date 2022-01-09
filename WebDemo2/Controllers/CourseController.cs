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
        //When the user clicks on the Course tab, the system will point to the Index() function of the CourseController
        public ActionResult Index()
        {
            var list = db.Courses.ToList<Course>();
            return View(list);
        }

        //When the user clicks the Create button on the Course page, the system will point to the Create() function (HttpGet method). 
        public ActionResult Create()
        {

            return View();
        }

        //When the user clicks the Create button on the Create Course page, the system will point to the Create() function (HttpPost method) of the CourseController
        [HttpPost]
        public ActionResult Create([Bind(Include = "Course_ID, Course_Name, Course_Category, Description")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Duplicate ID!");
            }
            return View(course);
        }

        //When the user clicks the Edit button on the Course page, the system will point to the Edit() function (HttpGet method) of the CourseController

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Course Course = db.Courses.Find(id);

            return View(Course);
        }

        //When the user clicks the Save button on the Edit Course page, the system will point to the Edit() function (HttpPost method) of the CourseController.

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

        //When the user clicks the Delete button on the Course page, a confirmation alert will be displayed

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