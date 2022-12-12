using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjeOdev.Models.EntityFramework;
using MvcProjeOdev.Models;

namespace MvcProjeOdev.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcProjeEntities1 db = new DbMvcProjeEntities1();
        public ActionResult Index()
        {
           var SinavNotlar= db.TblNotlar.ToList();
            return View(SinavNotlar);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(TblNotlar tbn)
        {
            db.TblNotlar.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notlar = db.TblNotlar.Find(id);
            return View("NotGetir", notlar);
        }
        
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TblNotlar p, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        
        {
            if (model.islem == "HESAPLA")
            {
                //islem 1
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
            }

            

            if (model.islem == "NOTGUNCELLE")
            {
                //islem2
                var  snv=db.TblNotlar.Find(p.NOTID);
                snv.SINAV1=p.SINAV1;
                snv.SINAV2=p.SINAV2;
                snv.SINAV3=p.SINAV3;
                snv.PROJE=p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
                

            }
            return View();
        }
    }
}