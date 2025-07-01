using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UdhariSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Welcome to Our Grocery & Bakery Shop";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Our Shop - Sweets, Namkeen, Bakery & More!";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us - We're open 7 days a week!";
            return View();
        }
    }
}