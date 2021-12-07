using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripApp.Models;

namespace TravelTripApp.Controllers
{
    public class iletisimController : Controller
    {
        Context db = new Context();
        // GET: Iletisim
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult MesajGonder()
        {

            return View();
        }

        [HttpPost]
        public ActionResult MesajGonder(iletisim iltsm)
        {
            db.iletisims.Add(iltsm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}