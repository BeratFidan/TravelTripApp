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
    public class AdminController : Controller
    {
        // GET: Admin
        Context db = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.Blogs.ToList();
            var degerler = db.Blogs.ToList().ToPagedList(sayfa,10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YeniBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Sil(int id)
        {
            var b = db.Blogs.Find(id);
            db.Blogs.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var blog = db.Blogs.Find(id);
            return View("BlogGetir",blog);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blog = db.Blogs.Find(b.ID);
            blog.Aciklama = b.Aciklama;
            blog.Baslik = b.Baslik;
            blog.Tarih = b.Tarih;
            blog.BlogImage = b.BlogImage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumlarListe()
        {
            var yorumlar = db.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = db.Yorumlars.Find(id);
            db.Yorumlars.Remove(b);
            db.SaveChanges();
            return RedirectToAction("YorumlarListe");
        }
        [HttpGet]
        public ActionResult YorumGetir(int id)
        {
            var yorum = db.Yorumlars.Find(id);
            return View("YorumGetir", yorum);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yorum = db.Yorumlars.Find(y.ID);
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;
            yorum.Yorum = y.Yorum;
            db.SaveChanges();
            return RedirectToAction("YorumlarListe");
        }
    }
}