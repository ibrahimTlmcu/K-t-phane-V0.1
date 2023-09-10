using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        DBKUTUPHANEEntitiesEnSon db = new DBKUTUPHANEEntitiesEnSon();
        public ActionResult Index()
        {

            var ktgr = db.TBLKATEGORI.ToList();
            return View(ktgr);
        }


        public ActionResult KategoriSil(int id) 
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }



        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI E)
        {
          
            db.TBLKATEGORI.Add(E);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult KategoriGuncelle(TBLKATEGORI K)
        {
            var ktgr = db.TBLKATEGORI.Find(K.ID);
            ktgr.AD = K.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    
    }
}