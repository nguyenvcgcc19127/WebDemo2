using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebDemo2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginManagement()
        {
            return View();
        }

        public ActionResult LoginProcess(string id)
        {
            if(id == "Staff")
            {
                return RedirectToAction("Login", "Staff");
            }
            if (id == "Trainer")
            {
                return RedirectToAction("Login", "Trainer");
            }
            if (id == "Trainee")
            {
                return RedirectToAction("Login", "Trainee");
            }
            return View();
        }

        /*public ActionResult ProfileManagement()
        {
            return View();
        }

        public ActionResult ProfileManagement(string id)
        {
            if (id == "Trainer")
            {
                return RedirectToAction("Login", "Trainer");
            }
            if (id == "Trainee")
            {
                return RedirectToAction("Login", "Trainee");
            }
            return View();
        }*/

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("LoginManagement", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}