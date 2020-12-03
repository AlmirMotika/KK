using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Karta
    {
        public int KartaId { get; set; }
        public float Cijena { get; set; }
        public int? VoznjaId { get; set; }
        public Voznja Voznja { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
