using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
                Session["Admin"] = acc.Admin;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or password is incorrect!");
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Staff_ID, Staff_Name, Email, Age, Address, Password, Admin")] Staff staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    staff.Password = EncodePassword(staff.Password);
                    db.Staffs.Add(staff);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Duplicate ID!");
            }
            return View(staff);
        }

        public static string EncodePassword(string Password)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(Password);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
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