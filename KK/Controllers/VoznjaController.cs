using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KK.Data;
using KK.Models;
using KK.ViewModels.VoznjaVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace KK.Controllers
{
    public class VoznjaController : Controller
    {
        private ApplicationDbContext context;
        public VoznjaController(ApplicationDbContext db)
        {
            context = db;
        }
        public IActionResult Voznje()
        {
            var model = context.Voznjas.Select(x => new VoznjaVM
            {
                ID = x.VoznjaId,
                Radnik=x.Radnik.Ime+" "+x.Radnik.Prezime,
                Linija=x.Linija.Polaziste.Naziv+"-"+x.Linija.Odrediste.Naziv,
                Vozilo=x.Vozilo.Tip_Vozila.Naziv,
            }).ToList();
            return View("Voznje", model);

        }
        public IActionResult DodajVoznju()
        {
            var model = new DodajVoznjuVM
            {
                Radnici = context.Radniks.Select(x => new SelectListItem { Text = x.Ime, Value = x.RadnikId.ToString() }).ToList(),
                Linije = context.Linijas.Select(x => new SelectListItem { Text = x.Polaziste.Naziv + "-" + x.Odrediste.Naziv, Value = x.LinijaId.ToString() }).ToList(),
                Vozila = context.Vozilos.Select(x => new SelectListItem { Text = x.Tip_Vozila.Naziv, Value = x.VoziloId.ToString() }).ToList()
            };
            return View("DodajVoznju", model);
        }
        [HttpPost]
        public IActionResult DodajVoznju(DodajVoznjuVM model)
        {
            Voznja voznja = new Voznja
            {
                RadnikId = model.RadnikID,
                LinijaId = model.LinijaID,
                VoziloId = model.VoziloID
            };
            context.Voznjas.Add(voznja);
            context.SaveChanges();
            return RedirectToAction("Voznje");
        }
        public IActionResult UrediVoznju(int id)
        {
            var model = context.Voznjas.Include(x => x.Radnik).Include(x => x.Linija).Include(x => x.Vozilo).SingleOrDefault(x => x.VoznjaId == id);
            if (model != null)
            {
                return View(new DodajVoznjuVM
                {
                    ID = model.VoznjaId,
                    LinijaID = model.Linija.LinijaId,
                    Linije = context.Linijas.Select(x => new SelectListItem { Text = x.Polaziste.Naziv + "-" + x.Odrediste.Naziv, Value = x.LinijaId.ToString() }).ToList(),
                    RadnikID = model.Radnik.RadnikId,
                    Radnici = context.Radniks.Select(x => new SelectListItem { Text = x.Ime, Value = x.RadnikId.ToString() }).ToList(),
                    VoziloID = model.Vozilo.VoziloId,
                    Vozila = context.Vozilos.Select(x => new SelectListItem { Text = x.Tip_Vozila.Naziv, Value = x.VoziloId.ToString() }).ToList()
                });
            }
            else
            {
                return RedirectToAction("Voznje");
            }

        }
        [HttpPost]
        public IActionResult UrediVoznju(DodajVoznjuVM model)
        {
            var voznja = context.Voznjas.FirstOrDefault(x => x.VoznjaId == model.ID);
            if (voznja != null)
            {
                voznja.RadnikId = model.RadnikID;
                voznja.LinijaId = model.LinijaID;
                voznja.VoziloId = model.VoziloID;
                context.SaveChanges();
            }
            return RedirectToAction("Voznje");
        }
        public IActionResult BrisiVoznju(int id)
        {
            var voznja = context.Voznjas.SingleOrDefault(x => x.VoznjaId == id);
            if (voznja != null)
            {
                context.Voznjas.Remove(voznja);
                context.SaveChanges();
            }
            return RedirectToAction("Voznje");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
