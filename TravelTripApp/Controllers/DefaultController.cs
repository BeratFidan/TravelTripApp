using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripApp.Models;

namespace TravelTripApp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context db = new Context();
        public ActionResult Index()
        {
            
            var degerler = db.Blogs.Take(4).ToList();
            return View(degerler);
        }
        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var degeler = db.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degeler);
        } 

        public PartialViewResult Partial2()
        {
            var deger = db.Blogs.Where(x => x.ID == 15).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var deger = db.Blogs.Take(10).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var deger = db.Blogs.Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = db.Blogs.OrderByDescending(x=> x.ID).Take(3).ToList();
            return PartialView(deger);
        }
    }
}