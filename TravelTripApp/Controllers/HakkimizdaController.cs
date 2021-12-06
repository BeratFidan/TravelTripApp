using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripApp.Models;

namespace TravelTripApp.Controllers
{
    public class HakkimizdaController : Controller
    {
        Context db = new Context();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var degerler = db.Hakkimizdas.ToList();

            return View(degerler);
        }
    }
}