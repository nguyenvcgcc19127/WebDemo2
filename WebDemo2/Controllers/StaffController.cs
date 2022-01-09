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

        //When the user clicks on the Staff tab, the system will point to the Index() function (HttpGet method) of the StaffController
        public ActionResult Index()
        {
            var list = db.Staffs.ToList<Staff>();
            return View(list);
        }

        //When the user run the web tab, the system will point to the Login() function (HttpGet method) of the StaffController
        public ActionResult Login()
        {

            return View();
        }

        //The user have to login with Staff account to access the system
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

        //When the user clicks the Create button on the Staff page, the system will point to the Create() function (HttpGet method)
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        //When the user clicks the Create button on the Create Staff page, the system will point to the Create() function (HttpPost method). 
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

        //The function hash the password
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

        //When the user clicks on the Edit button, the system will point to the Edit() function (HttpGet method) of the StaffController along with the id of the selected staff
        [HttpGet]
        public ActionResult Edit(string id)
        {
            Staff staff = db.Staffs.Find(id);
            return View(staff);
        }

        //When the user clicks the Save button on the Edit Staff page, the system will point to the Edit() function (HttpPost method). 
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Staff_ID, Staff_Name, Email, Age, Address, Password, Admin")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.Password = EncodePassword(staff.Password);
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        //When the user clicks the Delete button on the Staff page, a confirmation alert will be displayed
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