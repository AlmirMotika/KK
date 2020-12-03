using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KK.Helpers;

using KK.Data;

using KK.Models;
using KK.ViewModels.AdminVM;

namespace KK.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext context;
        public AdminController(ApplicationDbContext db)
        {
            context = db;
        }
        #region Drzava
        public IActionResult Drzave()
        {
            var drzave = context.Drzavas.Select(x => new DrzavaVM
            {
                Id = x.DrzavaId,
                Naziv = x.Naziv
            }).ToList();
            return View(drzave);
        }
        public IActionResult DodajDrzavu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DodajDrzavu(DrzavaVM model)
        {
            context.Drzavas.Add(new Drzava {
                Naziv = model.Naziv
            });
            context.SaveChanges();
            return RedirectToAction("Drzave");
        }
        public IActionResult UrediDrzavu(int id)
        {
            var drzave = context.Drzavas.FirstOrDefault(x => x.DrzavaId == id);
            if (drzave != null)
            {

                return View(new DrzavaVM { Id = id, Naziv = drzave.Naziv });
            }
            else
            {
                return RedirectToAction("Drzave");
            }

        }
        [HttpPost]
        public IActionResult UrediDrzavu(DrzavaVM model)
        {
            var drzave = context.Drzavas.FirstOrDefault(x => x.DrzavaId == model.Id);
            if (drzave != null)
            {
                drzave.Naziv = model.Naziv;
                context.SaveChanges();
            }
            return RedirectToAction("Drzave");
        }
        public IActionResult BrisiDrzavu(int id)
        {
            var drzave = context.Drzavas.FirstOrDefault(x => x.DrzavaId == id);
            if (drzave != null)
            {
                context.Drzavas.Remove(drzave);
                context.SaveChanges();
            }
            return RedirectToAction("Drzave");
        }
        #endregion
        #region Grad
        public IActionResult Gradovi()
        {
            var gradovi = context.Grads.Select(x => new GradVM
            {
                ID = x.GradId,
                Naziv = x.Naziv
            });
            return View(gradovi);
        }
        public IActionResult DodajGrad()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DodajGrad(GradVM model)
        {
            context.Grads.Add(new Grad
            {
                GradId = model.ID,
                Naziv = model.Naziv
            });
            context.SaveChanges();
            return RedirectToAction("Gradovi");
        }
        public IActionResult UrediGrad(int id)
        {
            var gradovi = context.Grads.FirstOrDefault(x => x.GradId == id);
            if (gradovi != null)
            {
                return View(new GradVM { ID = gradovi.GradId, Naziv = gradovi.Naziv });
            }
            else
            {
                return RedirectToAction("Gradovi");
            }
        }
        [HttpPost]

        public IActionResult UrediGrad(GradVM model)
        {
            var gradovi = context.Grads.FirstOrDefault(x => x.GradId == model.ID);
            if (gradovi != null)
            {
                gradovi.GradId = model.ID;
                gradovi.Naziv = model.Naziv;
                context.SaveChanges();
            }
            return RedirectToAction("Gradovi");
        }
        public IActionResult BrisiGrad(int id)
        {
            var gradovi = context.Grads.FirstOrDefault(x => x.GradId == id);
            if (gradovi != null)
            {
                context.Grads.Remove(gradovi);
                context.SaveChanges();

            }
            return RedirectToAction("Gradovi");
        }
        #endregion
        #region Obavijest
        public IActionResult Obavijesti()
        {
            var obavijesti = context.Obavijests.Select(x => new ObavijestiVM
            {
                ID = x.ID,
                Naslov = x.Naslov,
                Tekst = x.Tekst,
                Datum = x.Datum,
                Slika = CommonHelper.GetImageBase64(x.Slika)
            }).ToList();
            return View(obavijesti);
        }
        public IActionResult DodajObavijest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DodajObavijest(ObavijestiVM model, IFormFile file)
        {
            context.Obavijests.Add(new Obavijest
            {
                ID = model.ID,
                Naslov = model.Naslov,
                Tekst = model.Tekst,
                Datum = model.Datum,
                Slika = CommonHelper.GetImageByteArray(file)
            });
            context.SaveChanges();

            return RedirectToAction("Obavijesti");
        }
        public IActionResult UrediObavijest(int id)
        {
            var obavijesti = context.Obavijests.FirstOrDefault(x => x.ID == id);
            if (obavijesti != null)
            {
                return View(new ObavijestiVM
                {
                    ID = obavijesti.ID,
                    Naslov = obavijesti.Naslov,
                    Datum = obavijesti.Datum,
                    Tekst = obavijesti.Tekst,
                    Slika = CommonHelper.GetImageBase64(obavijesti.Slika)
                });
            }
            else
            {
                return RedirectToAction("Obavijesti");
            }
        }
        [HttpPost]
        public IActionResult UrediObavijest(ObavijestiVM model, IFormFile file)
        {
            var obavijesti = context.Obavijests.FirstOrDefault(x => x.ID == model.ID);
            if (obavijesti != null)
            {
                obavijesti.Naslov = model.Naslov;
                obavijesti.Datum = model.Datum;
                obavijesti.Tekst = model.Tekst;
                obavijesti.Slika = CommonHelper.GetImageByteArray(file);
                context.SaveChanges();
            }
            return RedirectToAction("Obavijesti");
        }
        public IActionResult BrisiObavijest(int id)
        {
            var obavijest = context.Obavijests.FirstOrDefault(x => x.ID == id);
            if (obavijest != null)
            {
                context.Obavijests.Remove(obavijest);
                context.SaveChanges();
            }
            return RedirectToAction("Obavijesti");
        }


        #endregion
        #region RadnikK
        public IActionResult RadnikKvalifikacije()
        {
            var radnikK = context.Radnik_Kvalifikacijas.Select(x => new RadnikKvalifikacijaVM
            {
                ID = x.RadnikKvalifikacijaId,
                Opis = x.Opis,
                CV = x.CV
            }).ToList();
            return View(radnikK);
        }
        public IActionResult DodajRadnikK()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DodajRadnikK(RadnikKvalifikacijaVM model)
        {

            context.Radnik_Kvalifikacijas.Add(new Radnik_Kvalifikacija
            {
                Opis = model.Opis,
                CV = model.CV
            });
            context.SaveChanges();

            return RedirectToAction("RadnikKvalifikacije");
        }
        public IActionResult UrediRadnikK(int id)
        {
            var radnikK = context.Radnik_Kvalifikacijas.FirstOrDefault(x => x.RadnikKvalifikacijaId == id);
            if (radnikK != null) {
                return View(new RadnikKvalifikacijaVM
                {
                    ID = radnikK.RadnikKvalifikacijaId,
                    Opis = radnikK.Opis,
                    CV = radnikK.CV
                });
            }
            else
            {
                return RedirectToAction("RadnikKvalifikacije");
            }

        }
        [HttpPost]
        public IActionResult UrediRadnikK(RadnikKvalifikacijaVM model)
        {
            var radnikK = context.Radnik_Kvalifikacijas.FirstOrDefault(x => x.RadnikKvalifikacijaId == model.ID);
            if (radnikK != null)
            {
                radnikK.Opis = model.Opis;
                radnikK.CV = model.CV;
                context.SaveChanges();
            }
            return RedirectToAction("RadnikKvalifikacije");
        }
        public IActionResult BrisiRadnikK(int id)
        {
            var radnikK = context.Radnik_Kvalifikacijas.FirstOrDefault(x => x.RadnikKvalifikacijaId == id);
            if (radnikK != null)
            {
                context.Radnik_Kvalifikacijas.Remove(radnikK);
                context.SaveChanges();
            }
            return RedirectToAction("RadnikKvalifikacije");
        }
        #endregion
        #region Radnik
        public IActionResult Radnici()
        {


            var model = context.Radniks
                .Select(j => new RadnikVM
                {
                    ID = j.RadnikId,
                    Ime = j.Ime,
                    Prezime = j.Prezime,
                    RadnikKvalifikacija = j.Radnik_Kvalifikacija.Opis,
                    DatumRodjenja = j.DatumRodjenja,
                    Grad = j.Grad.Naziv,
                    JMBG = j.JMBG


                }).OrderBy(i => i.Ime).ToList();
            return View("Radnici", model);
        }
        public IActionResult DodajRadnika()
        {
            var model = new DodajRVM
            {
                RadnikK = context.Radnik_Kvalifikacijas.Select
                (x => new SelectListItem { Text = x.Opis, Value = x.RadnikKvalifikacijaId.ToString() }).ToList(),
                Gradovi = context.Grads.Select(x => new SelectListItem { Text = x.Naziv, Value = x.GradId.ToString() }).ToList()
            };
            return View("DodajRadnika", model);
        }
        [HttpPost]
        public IActionResult DodajRadnika(DodajRVM model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("DodajRadnika");
            Radnik radnik = new Radnik
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                Radnik_KvalifikacijaId = model.RadnikKID,
                JMBG = model.JMBG,
                DatumRodjenja = model.DatumRodjenja,
                GradId = model.GradID
            };
            context.Radniks.Add(radnik);
            context.SaveChanges();
            return RedirectToAction("Radnici");
        }
        public IActionResult UrediRadnika(int id)
        {
            var radnik = context.Radniks.Include(i => i.Grad).Include(i => i.Radnik_Kvalifikacija).SingleOrDefault(x => x.RadnikId == id);
            if (radnik != null)
            {

                return View(new DodajRVM
                {
                    ID = radnik.RadnikId,
                    Ime = radnik.Ime,
                    Prezime = radnik.Prezime,
                    JMBG = radnik.JMBG,
                    DatumRodjenja = radnik.DatumRodjenja,
                    GradID = radnik.Grad.GradId,
                    Gradovi = context.Grads.Select(i => new SelectListItem { Text = i.Naziv, Value = i.GradId.ToString() }).ToList(),
                    RadnikK = context.Radnik_Kvalifikacijas.Select(i => new SelectListItem { Text = i.Opis, Value = i.RadnikKvalifikacijaId.ToString() }).ToList(),
                    RadnikKID = radnik.Radnik_Kvalifikacija.RadnikKvalifikacijaId

                });



            }
            else
            {
                return RedirectToAction("Radnici");
            }
        }
        [HttpPost]
        public IActionResult UrediRadnika(DodajRVM model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("UrediRadnika");
            var radnik = context.Radniks.FirstOrDefault(x => x.RadnikId == model.ID);
            if (radnik != null)
            {
                radnik.Ime = model.Ime;
                radnik.Prezime = model.Prezime;
                radnik.JMBG = model.JMBG;
                radnik.DatumRodjenja = model.DatumRodjenja;
                radnik.GradId = model.GradID;
                radnik.Radnik_KvalifikacijaId = model.RadnikKID;
                context.SaveChanges();
            }
            return RedirectToAction("Radnici");
        }

        public IActionResult BrisiRadnika(int id)
        {
            var radnik = context.Radniks.FirstOrDefault(x => x.RadnikId == id);
            if (radnik != null)
            {
                context.Radniks.Remove(radnik);
                context.SaveChanges();
            }


            return RedirectToAction("Radnici");

        }
        #endregion
        #region TipVozila
        public IActionResult TipVozila()
        {
            var tipovi = context.Tip_Vozilas.Select(x => new TipVozilaVM
            {
                ID = x.VoziloTipId,
                Naziv = x.Naziv,
                BrojSjedista = x.BrojSjedista
            }).ToList();
            return View(tipovi);
        }
        public IActionResult DodajTipVozila()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DodajTipVozila(TipVozilaVM model)
        {
            context.Tip_Vozilas.Add(new Tip_Vozila
            {
                Naziv = model.Naziv,
                BrojSjedista = model.BrojSjedista
            });
            context.SaveChanges();
            return RedirectToAction("TipVozila");
        }
        public IActionResult UrediTipVozila(int id)
        {
            var tip = context.Tip_Vozilas.FirstOrDefault(x => x.VoziloTipId == id);
            if (tip != null)
            {
                return View(new TipVozilaVM
                {
                    ID = tip.VoziloTipId,
                    Naziv = tip.Naziv,
                    BrojSjedista = tip.BrojSjedista
                });
            }
            else
            {
                return RedirectToAction("TipVozila");
            }
        }
        [HttpPost]
        public IActionResult UrediTipVozila(TipVozilaVM model)
        {
            var tip = context.Tip_Vozilas.SingleOrDefault(x => x.VoziloTipId == model.ID);
            if (tip != null)
            {
                tip.Naziv = model.Naziv;
                tip.BrojSjedista = model.BrojSjedista;
                context.SaveChanges();
            }
            return RedirectToAction("TipVozila");
        }
        public IActionResult BrisiTV(int id)
        {
            var tip = context.Tip_Vozilas.SingleOrDefault(x => x.VoziloTipId == id);
            if (tip != null)
            {
                context.Tip_Vozilas.Remove(tip);
                context.SaveChanges();
            }
            return RedirectToAction("TipVozila");
        }
        #endregion
        #region Vozilo
        public IActionResult Vozila()
        {
            var vozila = context.Vozilos.Select(x => new VoziloVM
            {
                ID = x.VoziloId,
                RegistracijskeOznake = x.RegistracijskeOznake,
                TipVozila = x.Tip_Vozila.Naziv,
                GodisteVozila = x.GodisteVozila
            }).OrderBy(x => x.GodisteVozila).ToList();
            return View("Vozila", vozila);
        }
        public IActionResult DodajVozilo()
        {
            var model = new DodajVoziloVM
            {
                Tipovi = context.Tip_Vozilas.Select(x => new SelectListItem { Text = x.Naziv, Value = x.VoziloTipId.ToString() }).ToList()
            };
            return View("DodajVozilo", model);
        }
        [HttpPost]
        public IActionResult DodajVozilo(DodajVoziloVM model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("DodajVozilo");
            Vozilo vozilo = new Vozilo
            {
                RegistracijskeOznake = model.RegistracijskaOznaka,
                Tip_VozilaId = model.TipoviID,
                GodisteVozila = model.GodisteVozila
            };
            context.Vozilos.Add(vozilo);
            context.SaveChanges();
            return RedirectToAction("Vozila");
        }
        public IActionResult UrediVozilo(int id)
        {
            var vozilo = context.Vozilos.Include(x => x.Tip_Vozila).SingleOrDefault(x => x.VoziloId == id);
            if (vozilo != null)
            {
                return View(new DodajVoziloVM
                {
                    RegistracijskaOznaka = vozilo.RegistracijskeOznake,
                    Tipovi = context.Tip_Vozilas.Select(x => new SelectListItem { Text = x.Naziv, Value = x.VoziloTipId.ToString() }).ToList(),
                    GodisteVozila = vozilo.GodisteVozila
                });
            }
            return RedirectToAction("Vozila");
        }
        [HttpPost]
        public IActionResult UrediVozilo(DodajVoziloVM model)
        {
            var vozilo = context.Vozilos.SingleOrDefault(x => x.VoziloId == model.ID);
            if (vozilo != null)
            {
                vozilo.RegistracijskeOznake = model.RegistracijskaOznaka;
                vozilo.Tip_VozilaId = model.TipoviID;
                vozilo.GodisteVozila = model.GodisteVozila;
            }
            context.SaveChanges();
            return RedirectToAction("Vozila");
        }
        public IActionResult BrisiVozilo(int id)
        {
            var vozilo = context.Vozilos.SingleOrDefault(x => x.VoziloId == id);
            if (vozilo != null)
            {
                context.Vozilos.Remove(vozilo);
                context.SaveChanges();
            }
            return RedirectToAction("Vozila");
        }
        #endregion
        #region TipLinije
        public IActionResult TipLinije()
        {
            var model = context.Tip_Linijes.Select(x => new TipLinijeVM { ID = x.LinijaTipId, Naziv = x.Naziv }).ToList();
            return View("TipLinije",model);
        }
        public IActionResult DodajTipLinije()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DodajTipLinije(TipLinijeVM model)
        {
            context.Tip_Linijes.Add(new Tip_Linije
            {
                Naziv = model.Naziv
            });
            context.SaveChanges();
            return RedirectToAction("TipLinije");
        }
        public IActionResult BrisiTipLinije(int id)
        {
            var tip = context.Tip_Linijes.FirstOrDefault(x => x.LinijaTipId == id);
            if (tip != null)
            {
                context.Tip_Linijes.Remove(tip);
                context.SaveChanges();
            }
            return RedirectToAction("TipLinije");
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

    }
}
