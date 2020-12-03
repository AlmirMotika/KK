using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.ViewModels.AdminVM
{
    public class RadnikVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string RadnikKvalifikacija { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Grad { get; set; }
    }
}
