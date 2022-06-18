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
    public class DashboardController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RollCall()
        {
            DersProgrami dersProgrami = new DersProgrami();
            dersProgrami.EgitmenAdi = Session["Kullanici"].ToString();
            return View(dersProgrami.DersProgrami_Getir());
        } 
        [HttpPost]
        public JsonResult OgrenciListesiGetir(int SinifId)
        {

            Ogrenci ogrenci =new Ogrenci();
            ogrenci.SinifId = SinifId;
          return Json(ogrenci.OgrencileriGetirSinifId()); 



        }
    }
}