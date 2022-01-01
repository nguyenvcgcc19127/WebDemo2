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

    public class CategoryController : Controller
    {
        Training db = new Training();
        // GET: Category
        public ActionResult Index()
        {
/*            if (Session["Admin"] != null && Session["Admin"].ToString() != "1")
            {
                return RedirectToAction("About", "Home");
            }
            else
            {*/
                var list = db.Categories.ToList<Category>();
                return View(list);
/*            }*/

        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Category_ID, Category_Name, Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Category category = db.Categories.Find(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Category_ID, Category_Name, Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {

            Category category = db.Categories.Find(id);

            db.Categories.Remove(category);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}