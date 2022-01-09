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
    public class TrainerController : Controller
    {
        Training db = new Training();
        // GET: Trainer
        public ActionResult Index()
        {
            var list = db.Trainers.ToList<Trainer>();
            return View(list);
        }

        

        public ActionResult Login()
        {

            return View();
        }

        [HttpGet]
        public ActionResult ViewProfile()
        {
            Trainer trainer = db.Trainers.ToList().Find(o => o.Email == Session["Email"].ToString());

            return View(trainer);
        }

        [HttpGet]
        public ActionResult EditViewProfile(string id)
        {
            Trainer trainer = db.Trainers.Find(id);

            return View(trainer);
        }

        [HttpPost]
        public ActionResult EditViewProfile([Bind(Include = "Trainer_ID, Trainer_Name, Email, Specialty, Age, Address, Password")] Trainer trainer)
        {
            /*Trainer trainer = db.Trainers.ToList().Find(o => o.Email == Session["Email"].ToString());
            if (ModelState.IsValid)
            {
                trainer.Trainer_Name = name;
                trainer.Age = age;
                trainer.Specialty = specialty;
                trainer.Address = address;
                db.SaveChanges();
                return RedirectToAction("ViewProfile");
            }
            return View(trainer);*/
            var list = db.Trainers.ToList();
            if (list != null) 
            {
                var trn = list.Find(o => o.Trainer_ID == trainer.Trainer_ID);
                trn.Trainer_Name = trainer.Trainer_Name;
                trn.Specialty = trainer.Specialty;
                trn.Age = trainer.Age;
                trn.Address = trainer.Address;
                db.SaveChanges();

                return RedirectToAction("ViewProfile");
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")] Trainer trainer)
        {
            Trainer acc = new Trainer();
                acc = db.Trainers.Where(p => p.Email == trainer.Email && p.Password == p.Password).FirstOrDefault();
            if (acc != null)
            {
                Session["Trainer"] = acc.Trainer_ID;
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
        public ActionResult Create([Bind(Include = "Trainer_ID, Trainer_Name, Email, Specialty, Age, Address, Password")] Trainer trainer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    trainer.Password = EncodePassword(trainer.Password);
                    db.Trainers.Add(trainer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Duplicate ID!");
            }
            return View(trainer);
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
            Trainer trainer = db.Trainers.Find(id);

            return View(trainer);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Trainer_ID, Trainer_Name, Email, Specialty, Age, Address, Password")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                trainer.Password = EncodePassword(trainer.Password);
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {

            Trainer trainer = db.Trainers.Find(id);

            db.Trainers.Remove(trainer);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}