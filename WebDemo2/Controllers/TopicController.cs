using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class TopicController : Controller
    {
        Training db = new Training();
        // GET: Topic

        // Index() to display list of Category
        public ActionResult Index()
        {
            var list = db.Topics.ToList<Topic>();
            return View(list);
        }

        // When the user clicks the Create button on the Topic page, the system will point to the Create() function (HttpGet method) of TopicController.
        public ActionResult Create()
        {

            return View();
        }

        // When the user clicks the Create button on the Create Topic page, the system will point to the Create() function (HttpPost method) of the TopicController
        [HttpPost]
        public ActionResult Create([Bind(Include = "Topic_ID, Topic_Name, Course_ID")] Topic topic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Topics.Add(topic);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Duplicate ID!");
            }
            return View(topic);
        }

        // When the user clicks the Edit button on the Topic page, the system will point to the Edit() function (HttpGet method) of TopicController.

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Topic topic = db.Topics.Find(id);

            return View(topic);
        }

        // When the user clicks the Edit button on the Topic page, the system will point to the Edit() function (HttpPost method) of TopicController.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Topic_ID, Topic_Name, Course_ID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        //When the user clicks the Delete button on the Topic page, a confirmation alert will be displayed
        [HttpGet]
        public ActionResult Delete(string id)
        {

            Topic topic = db.Topics.Find(id);

            db.Topics.Remove(topic);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}