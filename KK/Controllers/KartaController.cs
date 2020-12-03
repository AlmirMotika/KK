using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KK.Data;
using KK.ViewModels.Kartavm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace KK.Controllers
{
    public class KartaController : Controller
    {
        private ApplicationDbContext context;
        public KartaController(ApplicationDbContext db)
        {
            context = db;
        }
        public IActionResult Karte()
        {
            var model = context.Kartas.Include(x=>x.Voznja.Linija).Include(x=>x.ApplicationUser).Select(x => new KartaVM
            {
                ID = x.KartaId,
                Cijena = x.Cijena,
                Voznja = x.Voznja.Linija.Polaziste.Naziv + "-" + x.Voznja.Linija.Odrediste.Naziv,
                Vlasnik=x.ApplicationUser.FirstName+" "+x.ApplicationUser.LastName
                

            }).ToList();
            return View("Karte", model);
        }
        [HttpPost]
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
