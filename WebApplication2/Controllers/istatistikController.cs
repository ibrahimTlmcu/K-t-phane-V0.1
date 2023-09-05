using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hava() 
        {
             return Index();
        }

        public ActionResult HavaKart() 
        {
                
            return Index();
        }

        public ActionResult Galeri()
        {
            return View();
        }
        
    }

}