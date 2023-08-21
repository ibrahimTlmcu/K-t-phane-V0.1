using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntitiesEnSon yazar = new DBKUTUPHANEEntitiesEnSon();
        public ActionResult Index()
        {
            var deger = yazar.TBLYAZARR.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        public ActionResult YazarEkle(TBLYAZARR P) 
        {
            yazar.TBLYAZARR.Add(P);
            yazar.SaveChanges();
            return View();
        }
        
        public ActionResult YazarSil(int id )
        {
            var gyazar = yazar.TBLYAZARR.Find(id);
            yazar.TBLYAZARR.Remove(gyazar);
            yazar.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult YazarGetir(int id)
        {
            var yzr = yazar.TBLYAZARR.Find(id);
            return View("YazarGetir", yzr);
        }

        public ActionResult YazarGuncelle(TBLYAZARR p)
        {
            var yzr = yazar.TBLYAZARR.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            yazar.SaveChanges();
            return RedirectToAction("Index");

              
        }
    }
}