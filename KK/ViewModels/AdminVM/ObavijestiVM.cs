using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.ViewModels.AdminVM
{
    public class ObavijestiVM
    {
        public int ID { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }
        public string Slika { get; set; }
    }
}
