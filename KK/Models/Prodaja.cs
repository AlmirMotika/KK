using System;
using System.Collections.Generic;
using System.Text;

namespace KK.Models
{
    public class Prodaja
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public int KartaID { get; set; }
        public Karta Karta { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser{get;set;}

    }
}
