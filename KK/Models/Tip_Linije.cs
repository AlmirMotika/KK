using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Tip_Linije
    {
        [Key]
        public int LinijaTipId { get; set; }
        public string Naziv { get; set; }
    }
}
