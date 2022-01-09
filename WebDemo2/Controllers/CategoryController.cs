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
        // Index() to display list of Category
        public ActionResult Index()
        {
            if (Session["Admin"] != null && Session["Admin"].ToString() != "0")
            {
                return RedirectToAction("About", "Home");
            }
            else
            {
                var list = db.Categories.ToList<Category>();
                return View(list);
            }

        }

        // When the user clicks the Create button on the Category page, the system will point to the Create() function (HttpGet method) of CategoryController.

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        // When the user clicks the Create button on the Create Category page, the system will point to the Create() function (HttpPost method) of the CategoryController
        [HttpPost]
        public ActionResult Create([Bind(Include = "Category_ID, Category_Name, Description")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("","Duplicate ID!");
            }
            return View(category);
        }

        //When the user clicks the Edit button on the Category page, the system will point to the Edit() function (HttpGet method) of the CategoryController along with the id of the selected category
        [HttpGet]
        public ActionResult Edit(string id)
        {
            Category category = db.Categories.Find(id);

            return View(category);
        }

        //When the user clicks the Save button on the Edit Category page, the system will point to the Edit() function (HttpPost method) of the CategoryController
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

        //When the user clicks the Delete button on the Category page, a confirmation alert will be displayed
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