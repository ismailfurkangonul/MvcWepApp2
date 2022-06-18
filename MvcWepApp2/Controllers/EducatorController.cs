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
    public class EducatorController : Controller
    {
        // GET: Educator
        public ActionResult Index()
        {
            //TODO : Session kontrolü eklenecek...
            //dependecy injection...
            Egitmen egitmen = new Egitmen();
            Sinif sinif = new Sinif();
            EgitmenDTO egitmenDTO = new EgitmenDTO();
            egitmenDTO.Egitmenler = egitmen.EgitmenGetir();
            egitmenDTO.Siniflar = sinif.ListeGetir();
            return View(egitmenDTO);
        }

        [HttpPost]
        public ActionResult Ekle(string egitmenAdi, string egitmenSoyadi,int sinifId)
        {
            Egitmen egitmen = new Egitmen();

            egitmen.Ad = egitmenAdi;
            egitmen.Soyad = egitmenSoyadi;
            egitmen._Sinif = new Sinif { Id = sinifId };


            if (egitmen.Ekle())
            {
                return RedirectToAction("Index", "Educator");
            }
            else
            {
                return RedirectToAction("Index", "Educator");
            }
        }

        [HttpPost]

        public bool Sil(int Id)
        {
            Egitmen egitmen = new Egitmen();
            egitmen.Id = Id;
            return egitmen.Sil();

        }

    }
}