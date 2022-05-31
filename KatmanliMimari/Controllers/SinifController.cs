using Katmanli_BL;
using Katmanli_ENTITIES;
using KatmanliMimari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanliMimari.Controllers
{
    public class SinifController : Controller
    {
        Repository.SinifRepository repSinif = new Repository.SinifRepository();
        SinifModel model = new SinifModel();

        // GET: Sinif
        public ActionResult Index()
        {
            model.slist = repSinif.Listele();
            return View(model);
        }

        public ActionResult Detay(int id)
        {
            model.Sinif = repSinif.Bul(id);
            return View(model);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(SinifModel sm)
        {
            if (ModelState.IsValid)
            {
                Sinif s = new Sinif();
                s.Sube = sm.Sinif.Sube;
                s.Kademe = sm.Sinif.Kademe;
                if (repSinif.Listele().Where(x => x.Sube == sm.Sinif.Sube && x.Kademe == sm.Sinif.Kademe).Count() == null)
                {
                    s.SinifMevcudu = 0;
                }
                else
                {
                    s.SinifMevcudu = sm.Sinif.SinifMevcudu;
                }
               
                repSinif.Ekle(s);
                repSinif.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Guncelle(int id)
        {
            model.Sinif = repSinif.Bul(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Guncelle(int id, SinifModel sm)
        {
            if (ModelState.IsValid)
            {
                Sinif s = repSinif.Bul(id);
                s.Sube = sm.Sinif.Sube;
                s.Kademe = sm.Sinif.Kademe;
                s.SinifMevcudu = sm.Sinif.SinifMevcudu;
                repSinif.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Sil(int id)
        {
            Sinif s = repSinif.Bul(id);
            repSinif.Sil(s);
            repSinif.Guncel();
            return RedirectToAction("Index");
        }

        public ActionResult Asube()
        {
            model.slist = repSinif.GenelListe().Where(x => x.Sube.Contains("A")).ToList();
            return View(model);
        }

        public ActionResult Bsube()
        {
            model.slist = repSinif.GenelListe().Where(x => x.Sube.Contains("B")).ToList();
            return View(model);
        }
    }
}