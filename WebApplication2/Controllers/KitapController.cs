using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap

        DBKUTUPHANEEntitiesEnSon db = new DBKUTUPHANEEntitiesEnSon();
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar);
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
           
           
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {

            return View();
        }


        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBLKITAP.Find(id);
            return View("KitapGetir", ktp);
        }


    } 
}