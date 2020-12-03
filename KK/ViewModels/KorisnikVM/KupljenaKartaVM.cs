using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.ViewModels.KorisnikVM
{
    public class KupljenaKartaVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Datum { get; set; }
        public string Polaziste { get; set; }
        public string Odrediste { get; set; }
        public float Cijena { get; set; }
    }
}
