using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Linija
    {
        public int LinijaId { get; set; }
        public int? PolazisteID { get; set; }
        public Grad Polaziste { get; set; }
        public int? OdredisteID { get; set; }
        public Grad Odrediste { get; set; }
        public string TimePolaska { get; set; }
        public string TimeDolazak { get; set; }
        public string DuzinaPutovanja { get; set; }
        public int? Tip_LinijeID { get; set; }
        public Tip_Linije Tip_Linije { get; set; }
        public float Cijena { get; set; }
    }
}
