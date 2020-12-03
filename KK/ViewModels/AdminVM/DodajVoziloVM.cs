using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.ViewModels.AdminVM
{
    public class DodajVoziloVM
    {
        public int ID { get; set; }
        public string RegistracijskaOznaka { get; set; }
        public List<SelectListItem> Tipovi { get; set; }
        public int TipoviID { get; set; }
        public int GodisteVozila { get; set; }
    }
}
