using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassifiedApp.DAL;
using ClassifiedApp.Models;

namespace ClassifiedApp.Controllers
{
    public class HomeController : Controller
    {
        ClassifiedContext _context;
        
        public ActionResult Index()
        {
            _context = new ClassifiedContext();
            ViewBag.Categories = _context.Categories.Where(c => c.IsActive == true).ToList();
            return View();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
                _context = null;
            }

            base.Dispose(disposing);
        }
    }
}