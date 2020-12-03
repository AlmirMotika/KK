using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.ViewModels.LinijaVM
{
    public class DodajLinijuVM
    {
        public int ID { get; set;}
        public List<SelectListItem> Polaziste { get; set; }
        public int PolazisteID { get; set; }
        public List<SelectListItem> Odrediste { get; set; }
        public int OdredisteID { get; set; }
        public string VrijemePolaska { get; set; }
        public string VrijemeDolaska { get; set; }
        public string DuzinaPutovanja { get; set; }
        public List<SelectListItem> Linije { get; set; }
        public int LinijeID { get; set; }
        public float Cijena { get; set; }
    }
}
