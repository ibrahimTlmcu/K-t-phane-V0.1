using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odun

        DBKUTUPHANEEntitiesEnSon db = new DBKUTUPHANEEntitiesEnSon();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        { 
              return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET P) 
        {
            db.TBLHAREKET.Add(P);
            db.SaveChanges();
            return View();
        
        
        }
    }
}