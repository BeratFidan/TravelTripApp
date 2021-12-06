using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripApp.Models;
using PagedList;
using PagedList.Mvc;
namespace TravelTripApp.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context db = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.Blogs.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
       
        public ActionResult BlogDetay(int id)
        {

            //var blogbul = db.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = db.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = db.Yorumlars.Where(x => x.Blogid == id).ToList();
            
            return View(by);
        }
        public PartialViewResult Partial1()
        {
           
            by.Deger3 = db.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(by);
           
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
      public PartialViewResult YorumYap(Yorumlar y)
        {
            db.Yorumlars.Add(y);
            db.SaveChanges();
            return PartialView();
        }
    }
}