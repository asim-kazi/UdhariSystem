using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdhariSystem.Models;

namespace UdhariSystem.Controllers
{
    public class BorrowerController : Controller
    {
        BorrowerDataAccess db = new BorrowerDataAccess();

        public ActionResult Index(string search)
        {
            var borrowers = db.GetBorrowers(search);
            ViewBag.Total = borrowers.Sum(b => b.AmountOwed);
            return View(borrowers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Borrower b)
        {
            if (ModelState.IsValid)
            {
                db.AddBorrower(b);
                return RedirectToAction("Index");
            }
            return View(b);
        }

        public ActionResult Edit(int id)
        {
            var borrower = db.GetBorrowerById(id);
            return View(borrower);
        }

        [HttpPost]
        public ActionResult Edit(Borrower b)
        {
            db.UpdateBorrower(b);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            db.DeleteBorrower(id);
            return RedirectToAction("Index");
        }
    }
}