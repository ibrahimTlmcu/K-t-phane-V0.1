using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik

        DBKUTUPHANEEntitiesEnSon db = new DBKUTUPHANEEntitiesEnSon();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            var deger2 = db.TBLKITAP.Count();
            var deger3 = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger5 = db.TBLKITAP.GroupBy(X => X.YAYINEVI).OrderByDescending(z => z.Count()).
            Select(y=> new {y.Key}).FirstOrDefault();




            ViewBag.deger5 = deger5;
            ViewBag.deger4 = deger4;
            ViewBag.deger1 = deger1;
            ViewBag.deger2 = deger2;
            ViewBag.deger3 = deger3;
            return View();
        }

        public ActionResult Hava() 
        {
             return Index();
        }

        public ActionResult HavaKart() 
        {
                
            return Index();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("/web2/resimler/")
                    ,Path.GetFileName(dosya.FileName));

                dosya.SaveAs(dosyayolu);
            }

            return RedirectToAction("Galeri");
        }
        
        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKITAP.Count();
            var deger2 = db.TBLUYELER.Count();
            var deger4 = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            var deger5 = db.TBLKATEGORI.Count();


        
            ViewBag.deger1 = deger1;
            ViewBag.deger2 = deger2;
            ViewBag.deger4 = deger4;
            ViewBag.deger5 = deger5;


            return View();
        }
        
    }

}