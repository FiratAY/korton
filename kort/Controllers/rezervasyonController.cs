using kort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System.Net.Mail;
using System.Net;
public class sıra
{
     int top = 0;
     Rezervasyon rezerve;
     Musteri[] musteri;
     bool ekle(Musteri mus)
    {
        musteri = new Musteri[20];
        if (top<20)
        {
            musteri[top] = mus;
            return true;
        }
        else
        {
            return false;
        }
    }
     Musteri sil()
    {
        return musteri[0]; 
    }
}

namespace kort.Controllers
{

    public class rezervasyonController : Controller
    {
        TenisKortuEntities tdb = new TenisKortuEntities();
        // GET: rezervasyon
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult cortsırala(DateTime tarih)
        {
            ViewBag.tarih = tarih;
            ViewBag.kort = tdb.Kort;
            ViewBag.rezer = tdb.Rezervasyon.Where(x=>x.Tarih==tarih);
            return View();
        }
       
        public ActionResult rezerveEt()
        {
            ViewBag.isim = User.Identity.GetUserName();
            //ViewBag.tarih = tarih;
            return View();
        }
        [HttpPost]
        public ActionResult rezerveEt(FormCollection form)
        {
            Guid a = Guid.NewGuid();
            Musteri must = new Musteri();
            Rezervasyon rez = new Rezervasyon();
            IFormatProvider culture = new CultureInfo("tr-TR", true);
            sıra sır = new sıra();
            rez.No = Convert.ToInt32(form["kort"]);
            String x = form["tarih"];
            rez.Tarih = DateTime.ParseExact(x, @"dd-MM-yyyy\THH:mm",CultureInfo.InvariantCulture);
            must.Ad_Soyad = form["ad"];
            must.Adres = form["adres"];
            must.Mail = form["mail"];
            must.ID = a;
            must.Telefon = form["tel"];
            tdb.Rezervasyon.Add(rez);
            tdb.Musteri.Add(must);
            tdb.SaveChanges();
            
            return View("index");
        }
        
        public ActionResult rezerveSil()
        {
            mailAt();
            return View();
        }
        [HttpPost]
        public ActionResult rezerveSil(FormCollection form)
        {
            var t =Convert.ToInt32(form["kort"]);
            var silinecek = tdb.Rezervasyon.FirstOrDefault(x =>x.ID == t);
            tdb.Rezervasyon.Remove(silinecek);
            tdb.SaveChanges();
            return View("index");
        }
        public ActionResult takipEt()
        {
            
            return View();
        }
        public void mailAt()
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("karay0825@gmail.com", "frty-*120");
            MailMessage mesaj = new MailMessage("karay0825@gmail.com", "User.Identity.GetUserName");
            mesaj.Body = "Takip ettiğiniz kortun rezervasyonu iptal edilmiştir. isterseniz sıra alabilirsiniz.";
            mesaj.Subject = "Kort rezervasyonu";
            smtp.Send(mesaj);
            
        }
    }


}