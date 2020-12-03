using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Tip_Vozila
    {
        [Key]
        public int VoziloTipId { get; set; }
        public string Naziv { get; set; }
        public int BrojSjedista { get; set; }
    }
}
