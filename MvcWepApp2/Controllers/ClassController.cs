using MvcWepApp2.Core;
using MvcWepApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWepApp2.Controllers
{
    [SessionControl]
    public class ClassController : Controller
    {
        
        public ActionResult Index()
        {
            
            Sinif sinif = new Sinif();
            return View(sinif.ListeGetir());
        }

        [HttpPost]
        public ActionResult Ekle(string sinifAdi, string sinifKodu)
        {
            Sinif sinif = new Sinif();

            sinif.Adi= sinifAdi;
            sinif.Kodu = sinifKodu;
            

            if (sinif.Ekle())
            {
                return RedirectToAction("Index", "Class");
            }
            else
            {
                return RedirectToAction("Index", "Class");
            }
        }

        [HttpPost]

        public bool Sil(int Id)
        {
            Sinif sinif = new Sinif();
            sinif.Id = Id;
            return sinif.Sil();

        }
        

        public ActionResult detailclass()
        {
            return View();


        }
        [HttpPost]
        public ActionResult ProgramEkle (DateTime dersbaslangic,DateTime dersbitis,string dersadi,int Id)
        {
            DersProgrami dersProgrami = new DersProgrami();

            dersProgrami.Baslangic = dersbaslangic;
            dersProgrami.Bitis = dersbitis;
            dersProgrami.DersAdi = dersadi;
            dersProgrami.SinifId = Id;


            if (dersProgrami.ProgramEkle())
            {
                return RedirectToAction("detailclass", "Class");
            }
            else
            {
                return RedirectToAction("detailclass", "Class");
            }
           



        }
    }
}