using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Radnik_Kvalifikacija
    {
        [Key]
        public int RadnikKvalifikacijaId { get; set; }
        public string Opis { get; set; }
        public string CV { get; set; }
    }
}
