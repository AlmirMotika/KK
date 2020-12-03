using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KK.Data;
using KK.Models;
using KK.ViewModels.LinijaVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace KK.Controllers
{
    public class LinijaController : Controller
    {
        private ApplicationDbContext context;
        public LinijaController(ApplicationDbContext db)
        {
            context = db;
        }
        public IActionResult Linije()
        {
            var model = context.Linijas.Select(x => new LinijaVM
            {
                ID = x.LinijaId,
                Polaziste = x.Polaziste.Naziv,
                Odrediste = x.Odrediste.Naziv,
                VrijemePolaska = x.TimePolaska,
                VrijemeDolaska = x.TimeDolazak,
                DuzinaPutovanja = x.DuzinaPutovanja,
                TipLinije = x.Tip_Linije.Naziv,
                Cijena = x.Cijena
            }).OrderBy(x=>x.Cijena).ToList();
            return View("Linije", model);
        }
        public IActionResult Dodaj()
        {
            var model = new DodajLinijuVM
            {
                Polaziste = context.Grads.Select(x => new SelectListItem { Text = x.Naziv, Value = x.GradId.ToString() }).ToList(),
                Odrediste = context.Grads.Select(x => new SelectListItem { Text = x.Naziv, Value = x.GradId.ToString() }).ToList(),
                Linije = context.Tip_Linijes.Select(x => new SelectListItem { Text = x.Naziv, Value = x.LinijaTipId.ToString() }).ToList()
            };
            return View("Dodaj", model);
        }
        [HttpPost]
        public IActionResult Dodaj(DodajLinijuVM model)
        {
            Linija linija = new Linija
            {
                PolazisteID = model.PolazisteID,
                OdredisteID = model.OdredisteID,
                TimePolaska = model.VrijemePolaska,
                TimeDolazak = model.VrijemeDolaska,
                DuzinaPutovanja = model.DuzinaPutovanja,
                Tip_LinijeID = model.LinijeID,
                Cijena = model.Cijena
            };
            context.Linijas.Add(linija);
            context.SaveChanges();
            return RedirectToAction("Linije");

        }
        public IActionResult Edit(int id)
        {
            var linija = context.Linijas.Include(x => x.Polaziste).Include(x => x.Odrediste).Include(x => x.Tip_Linije).SingleOrDefault(x => x.LinijaId == id);
            if (linija != null)
            {
                return View(new DodajLinijuVM
                {
                    ID = linija.LinijaId,
                    PolazisteID = linija.Polaziste.GradId,
                    Polaziste = context.Grads.Select(i => new SelectListItem { Text = i.Naziv, Value = i.GradId.ToString() }).ToList(),
                    OdredisteID=linija.Odrediste.GradId,
                    Odrediste=context.Grads.Select(i=>new SelectListItem { Text=i.Naziv,Value=i.GradId.ToString()}).ToList(),
                    VrijemePolaska=linija.TimePolaska,
                    VrijemeDolaska=linija.TimeDolazak,
                    LinijeID=linija.Tip_Linije.LinijaTipId,
                    Linije=context.Tip_Linijes.Select(i=>new SelectListItem { Text=i.Naziv,Value=i.LinijaTipId.ToString()}).ToList(),
                    DuzinaPutovanja=linija.DuzinaPutovanja,
                    Cijena=linija.Cijena
                });
            }
            else
            {
                return RedirectToAction("Linije");
            }

        }
        [HttpPost]
        public IActionResult Edit(DodajLinijuVM model)
        {
            var linija = context.Linijas.SingleOrDefault(x => x.LinijaId == model.ID);
            if (linija != null)
            {
                linija.PolazisteID = model.PolazisteID;
                linija.OdredisteID = model.OdredisteID;
                linija.TimePolaska = model.VrijemePolaska;
                linija.TimeDolazak = model.VrijemeDolaska;
                linija.DuzinaPutovanja = model.DuzinaPutovanja;
                linija.Tip_LinijeID = model.LinijeID;
                linija.Cijena = model.Cijena;
                context.SaveChanges();
            }
            return RedirectToAction("Linije");
        }
        public IActionResult Brisi(int id)
        {
            var linija = context.Linijas.FirstOrDefault(x => x.LinijaId == id);
            if (linija != null)
            {
                context.Linijas.Remove(linija);
                context.SaveChanges();
            }
            return RedirectToAction("Linije");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
