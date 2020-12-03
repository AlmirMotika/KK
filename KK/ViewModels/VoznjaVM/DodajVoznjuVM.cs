using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.ViewModels.VoznjaVM
{
    public class DodajVoznjuVM
    {
        public int ID { get; set; }
        public int RadnikID { get; set; }
        public List<SelectListItem> Radnici { get; set; }
        public int LinijaID { get; set; }
        public List<SelectListItem> Linije { get; set; }
        public int VoziloID { get; set; }
        public List<SelectListItem> Vozila { get; set; }
    }
}
