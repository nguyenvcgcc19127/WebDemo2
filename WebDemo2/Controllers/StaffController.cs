using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class StaffController : Controller
    {
        Training db = new Training();
        // GET: Staff
        public ActionResult Index()
        {
            var list = db.Staffs.ToList<Staff>();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")] Staff staff)
        {
            Staff acc = new Staff();
            acc = db.Staffs.Where(p => p.Email == staff.Email && p.Password == p.Password).FirstOrDefault();
            if (acc != null)
            {
                Session["Email"] = acc.Email;
                return RedirectToAction("index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

            [HttpPost]
        public ActionResult Create([Bind(Include = "Staff_ID, Staff_Name, Email, Age, Address, Password, Admin")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Staff staff = db.Staffs.Find(id);

            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Staff_ID, Staff_Name, Email, Age, Address, Password, Admin")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {

            Staff staff = db.Staffs.Find(id);

            db.Staffs.Remove(staff);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}