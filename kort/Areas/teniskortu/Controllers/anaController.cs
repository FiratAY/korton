using kort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kort.Areas.teniskortu.Controllers
{
    public class anaController : Controller
    {
        // GET: teniskortu/Home
        TenisKortuEntities tdb = new TenisKortuEntities();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult calendar()
        {
            return View();
        }
        public ActionResult tablo()
        {
            ViewBag.uye = tdb.Musteri;
            return View();
        }
        public ActionResult kortlar()
        {
            return View();
        }
    }
}