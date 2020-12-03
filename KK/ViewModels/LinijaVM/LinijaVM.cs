using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KK.ViewModels.LinijaVM
{
    public class LinijaVM
    {
        public int ID { get; set; }
        public string Polaziste { get; set; }
        public string Odrediste { get; set; }
        public string VrijemePolaska { get; set; }
        public string VrijemeDolaska { get; set; }
        public string DuzinaPutovanja { get; set; }
        public string TipLinije { get; set; }
        public float Cijena { get; set; }
    }
}
