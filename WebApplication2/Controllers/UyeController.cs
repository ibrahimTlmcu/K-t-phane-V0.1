using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace WebApplication2.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye

        DBKUTUPHANEEntitiesEnSon uye = new DBKUTUPHANEEntitiesEnSon();

        public ActionResult Index(int sayfa =1)
        {
            //var  uyeler = uye.TBLUYELER.ToList();
            var degerler = uye.TBLUYELER.ToList().ToPagedList(sayfa, 8);
            return View(degerler);

        }

        public ActionResult UyeSil(int id ) 
        {
            var pers = uye.TBLUYELER.Find(id);
            uye.TBLUYELER.Remove(pers);
            uye.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER id )
        {

            if(!ModelState.IsValid)
            {
                return View("UyeEkle");
            }


            uye.TBLUYELER.Add(id);
            uye.SaveChanges();
            return View();   
        }

    }
}