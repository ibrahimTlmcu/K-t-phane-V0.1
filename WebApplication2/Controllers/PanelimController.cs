using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim

        DBKUTUPHANEEntitiesEnSon db = new DBKUTUPHANEEntitiesEnSon();


        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }

        [HttpPost]

        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.KULLANICIADI = p.KULLANICIADI;
            
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult Kitaplarim()
        {
            return View();
        }

    
    
    }
}