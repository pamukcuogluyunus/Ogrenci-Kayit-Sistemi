using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjeOdev.Models.EntityFramework;


namespace MvcProjeOdev.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
        DbMvcProjeEntities1 db=new DbMvcProjeEntities1();
        public ActionResult Index()
        {
            var kulup=db.TblKulupler.ToList();
            return View(kulup);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TblKulupler p2)
        {
            db.TblKulupler.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup=db.TblKulupler.Find(id);
            db.TblKulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TblKulupler.Find(id);
            return View("KulupGetir", kulup);

        }
        public ActionResult Guncelle(TblKulupler p)
        {
            var klp = db.TblKulupler.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index","Kulup");
        }
    }
}