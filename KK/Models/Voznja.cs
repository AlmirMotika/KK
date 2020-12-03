using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Voznja
    {
        public int VoznjaId { get; set; }
        public int? RadnikId { get; set; }
        public Radnik Radnik { get; set; }
        public int? LinijaId { get; set; }
        public Linija Linija { get; set; }
        public int? VoziloId { get; set; }
        public Vozilo Vozilo { get; set; }
    }
}
