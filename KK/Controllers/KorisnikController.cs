using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using KK.Data;
using KK.ViewModels.LinijaVM;
using KK.Models;
using KK.ViewModels.Kartavm;
using Microsoft.AspNetCore.Identity;

namespace KK.Controllers
{
    public class KorisnikController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public KorisnikController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            context = db;
            _userManager = userManager;
        }
        
        public IActionResult LinijeKarta()
        {
            var model = context.Linijas.Select(x => new LinijaVM
            {
                ID = x.LinijaId,
                Polaziste = x.Polaziste.Naziv,
                Odrediste = x.Odrediste.Naziv,
                VrijemePolaska = x.TimePolaska,
                VrijemeDolaska = x.TimeDolazak,
                DuzinaPutovanja = x.DuzinaPutovanja,
                TipLinije=x.Tip_Linije.Naziv,
                Cijena = x.Cijena
            }).OrderBy(x => x.Cijena).ToList();
            return View("LinijeKarta", model);
        }
      
        public IActionResult KupiKartu(int id)
        {
            var model = context.Voznjas.FirstOrDefault(x => x.LinijaId == id);
            var userID = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(userID).Result;
            if (model != null)
            {
                Karta karta = new Karta
                {
                    VoznjaId = model.VoznjaId,
                    Cijena = context.Linijas.FirstOrDefault(x => x.LinijaId == model.LinijaId).Cijena,
                    ApplicationUserID = userID
                };
                context.Kartas.Add(karta);
                context.SaveChanges();
                Prodaja prodaja = new Prodaja
                {
                    Datum = DateTime.Now,
                    KartaID=karta.KartaId,
                    ApplicationUserID=userID
                };
                context.Prodaje.Add(prodaja);
                context.SaveChanges();
                var voznja1 = context.Voznjas.Include(x => x.Linija.Polaziste).Include(x => x.Linija.Odrediste).SingleOrDefault(x => x.VoznjaId == karta.VoznjaId);
                
                return View(new KartaVM { ID=karta.KartaId,Voznja=voznja1.Linija.Polaziste.Naziv+"-"+voznja1.Linija.Odrediste.Naziv,Cijena=karta.Cijena, Vlasnik = user.FirstName + " " + user.LastName });
            }
            else
            {
                return RedirectToAction("Linije");
            }
        }
        [HttpPost]
        public IActionResult KupiKartu(KartaVM karta)
        {
       
            return View(karta);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
