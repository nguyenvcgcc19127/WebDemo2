using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models;

namespace WebDemo2.Controllers
{
    public class TraineeController : Controller
    {
        Training db = new Training();
        // GET: Trainee
        public ActionResult Index()
        {
            var list = db.Trainees.ToList<Trainee>();
            return View(list);
        }

        [HttpGet]
        public ActionResult ViewProfile()
        {
            Trainee trainee = db.Trainees.ToList().Find(o => o.Email == Session["Email"].ToString());

            return View(trainee);
        }


        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")] Trainee trainee)
        {
            Trainee acc = new Trainee();
            acc = db.Trainees.Where(p => p.Email == trainee.Email && p.Password == p.Password).FirstOrDefault();
            if (acc != null)
            {
                Session["Trainee"] = acc.Trainee_ID;
                Session["Email"] = acc.Email;
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
        public ActionResult Create([Bind(Include = "Trainee_ID, Trainee_Name, Email, Age, Date_of_Birth, Education, Password")] Trainee trainee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    trainee.Password = EncodePassword(trainee.Password);
                    db.Trainees.Add(trainee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Duplicate ID!");
            }
            return View(trainee);
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
            Trainee trainee = db.Trainees.Find(id);

            return View(trainee);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Trainee_ID, Trainee_Name, Email, Age, Date_of_Birth, Education, Password")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                trainee.Password = EncodePassword(trainee.Password);
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {

            Trainee trainee = db.Trainees.Find(id);

            db.Trainees.Remove(trainee);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}