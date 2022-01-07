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
        public ActionResult Index()
        {
            var list = db.Topics.ToList<Topic>();
            return View(list);
        }
        public ActionResult Create()
        {

            return View();
        }

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

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Topic topic = db.Topics.Find(id);

            return View(topic);
        }

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