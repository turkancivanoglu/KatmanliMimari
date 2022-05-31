using Katmanli_ENTITIES;
using KatmanliMimari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Katmanli_BL.Repository;

namespace KatmanliMimari.Controllers
{
    public class OgrenciController : Controller
    {
        OgrenciRepository repOgr = new OgrenciRepository();
        SinifRepository repSinif = new SinifRepository();
        SinifModel sm = new SinifModel();

        // GET: Ogrenci
        public ActionResult Index()
        {
            sm.olist = repOgr.Listele();
            return View(sm);
        }

        public ActionResult Ekle()
        {
            sm.KademeListesi = repSinif.GenelListe().Select(x => new SelectListItem
            {
                Text = x.Kademe.ToString(),
                Value = x.Kademe.ToString()
            }).Distinct();

            sm.SubeListesi = repSinif.GenelListe().Select(x => new SelectListItem
            {
                Text = x.Sube,
                Value = x.Sube
            }).Distinct();

            return View(sm);
        }

        [HttpPost]
        public ActionResult Ekle(SinifModel model)
        {
            if (ModelState.IsValid)
            {
                Ogrenci o = new Ogrenci();
                o.Ad = model.Ogrenci.Ad;
                o.Soyad = model.Ogrenci.Soyad;
                o.Yas = model.Ogrenci.Yas;
                o.Adres = model.Ogrenci.Adres;
                o.Sube = model.Sinif.Sube;
                o.Kademe = model.Sinif.Kademe;
                repOgr.Ekle(o);
                sm.Sinif = repSinif.Set().FirstOrDefault(x => x.Sube == model.Sinif.Sube && x.Kademe == model.Sinif.Kademe);
                sm.Sinif.SinifMevcudu += 1;
                repSinif.Guncel();
                return RedirectToAction("Index");
            }       
            return View();
        }

        public ActionResult Detay(int id)
        {
            sm.Ogrenci = repOgr.Bul(id);
            return View(sm);
        }

        public ActionResult Guncelle(int id, SinifModel sm)
        {
            if (ModelState.IsValid)
            {
                Ogrenci o = repOgr.Bul(id);
                o.Ad = sm.Ogrenci.Ad;
                o.Soyad = sm.Ogrenci.Soyad;
                o.Yas = sm.Ogrenci.Yas;
                o.Adres = sm.Ogrenci.Adres;
                o.Kademe = sm.Ogrenci.Kademe;
                o.Sube = sm.Ogrenci.Sube;
                repOgr.Guncel();
                sm.Sinif = repSinif.Set().FirstOrDefault(x => x.Sube == o.Sinif.Sube && x.Kademe == o.Sinif.Kademe);
                sm.Sinif.SinifMevcudu += 1;
                repSinif.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}