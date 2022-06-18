using MvcWepApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWepApp2.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string kullaniciAdi, string sifre)
        {

            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAdi = kullaniciAdi;
            kullanici.Sifre = sifre;

            if (kullanici.GirisYap())
            {
                Session["Kullanici"] = kullaniciAdi;
                Session["Yetki"] = "Yönetici";

                return RedirectToAction("Index", "Dashboard");
            }

            return View();

        }
        public ActionResult EducatorLogin()
        {

            return View();


        }
        [HttpPost]
        public ActionResult EducatorLogin(string kullaniciAdi, string sifre)
        {
            Egitmen egitmen = new Egitmen();
            egitmen.Ad = kullaniciAdi;
            egitmen.Sifre = sifre;
            if (egitmen.GirisYap())
            {
                Session["Kullanici"] = kullaniciAdi;
                Session["Yetki"] = "Eğitmen";
                return RedirectToAction("RollCall", "Dashboard");


            }
            return View();


        }

    }
}