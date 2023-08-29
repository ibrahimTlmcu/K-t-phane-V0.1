using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel


        DBKUTUPHANEEntitiesEnSon db = new DBKUTUPHANEEntitiesEnSon(); 
        public ActionResult Index()
        {
            var personel = db.TBLPERSONEL.ToList();
            return View(personel);
        }


        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");   

        }


        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", prs);
        }

        public ActionResult PersonelGuncelle(TBLPERSONEL P)
        {
            var prs = db.TBLPERSONEL.Find(P.ID);
            prs.PERSONEL = P.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]

        public ActionResult PersonelEkle()
        {
            return View();
        }
  
        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL p)
        {

            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }

            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}