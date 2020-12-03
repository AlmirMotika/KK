using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.ViewModels.AdminVM
{
    public class DodajRVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<SelectListItem> Gradovi { get; set; }
        public int GradID { get; set; }
        public List<SelectListItem> RadnikK { get; set; }
        public int RadnikKID { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }

    }
}
