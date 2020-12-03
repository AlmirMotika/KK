using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Obavijest
    {
        public int ID { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }

        public byte[] Slika { get; set; }
      
    }
}
