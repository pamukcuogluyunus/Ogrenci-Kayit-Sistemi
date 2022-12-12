using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjeOdev.Models.EntityFramework;

namespace MvcProjeOdev.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcProjeEntities1  db =new DbMvcProjeEntities1();
        public ActionResult Index()
        {
            var ogrenciler = db.TblOgrenciler.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TblKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }   ).ToList();
            ViewBag.dgr = degerler;                              
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TblOgrenciler p3)
        {
            var klp = db.TblKulupler.Where(m => m.KULUPID == p3.TblKulupler.KULUPID).FirstOrDefault();
            p3.TblKulupler = klp;
            db.TblOgrenciler.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TblOgrenciler.Find(id);
            db.TblOgrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TblOgrenciler.Find(id);

          
            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(TblOgrenciler p)
        {
            var ogr = db.TblOgrenciler.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTO = p.OGRFOTO;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }

    }
}