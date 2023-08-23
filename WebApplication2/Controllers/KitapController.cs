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
        public ActionResult Index(string p)
        {
            
            var kitaplar = from k in db.TBLKITAP select k;
            if(!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m=>m.AD.Contains(p));
            }
   
       
             return View(kitaplar.ToList());
            
         
          
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
           
           
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {

            db.TBLKITAP.Add(p);
            db.SaveChanges();

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


        public ActionResult KitapGuncelle(TBLKITAP k)
        {
            var ktp = db.TBLKITAP.Find(k.ID);
            ktp.AD = k.AD;
            ktp.KATEGORI = k.KATEGORI;
            ktp.YAZAR = k.YAZAR;
            ktp.BASIMYIL = k.BASIMYIL;
            ktp.YAYINEVI = k.YAYINEVI;
            ktp.SAYFA = k.SAYFA;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}