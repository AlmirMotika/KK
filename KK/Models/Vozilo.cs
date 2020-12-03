using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Vozilo
    {
        public int VoziloId { get; set; }
        public string RegistracijskeOznake { get; set; }
        public int? Tip_VozilaId { get; set; }
        public Tip_Vozila Tip_Vozila { get; set; }
        public int  GodisteVozila { get; set; }
    }
}
