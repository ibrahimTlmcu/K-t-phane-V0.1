using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
using WebApplication2.Models.siniflarim;


namespace WebApplication2.Controllers
{
    public class vitrinController : Controller
    {
        // GET: vitrin

        DBKUTUPHANEEntitiesEnSon db = new DBKUTUPHANEEntitiesEnSon();


        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();

            cs.Deger1 = db.TBLKITAP.ToList();
            cs.Deger2 = db.TBLHAKKIMIZ.ToList();

           // var degerler = db.TBLKITAP.ToList();
            return View(cs);
        }

        [HttpPost]

        public ActionResult Index(TBLILETISIM t)
        {
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}