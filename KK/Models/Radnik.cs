using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Radnik
    {
        public int RadnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? Radnik_KvalifikacijaId { get; set; }
        public Radnik_Kvalifikacija Radnik_Kvalifikacija { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int? GradId { get; set; }
        public Grad Grad { get; set; }
    }
}
