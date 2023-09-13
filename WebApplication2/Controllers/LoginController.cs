using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntitiesEnSon db = new DBKUTUPHANEEntitiesEnSon();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                Session["Ad"] = bilgiler.AD.ToString();
                TempData["Soyad"] = bilgiler.SOYAD.ToString();
                TempData["KullaniciAdi"] = bilgiler.KULLANICIADI.ToString();
                TempData["Sifre"] = bilgiler.SIFRE.ToString();
                TempData["Ad"] = bilgiler.AD.ToString();
                return RedirectToAction("Index","Panelim");
                
            }
            else
            {
                return View();
            }
          
        }
    }
}