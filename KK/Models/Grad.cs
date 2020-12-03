using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KK.Models
{
    public class Grad
    {
        [Key]
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int? DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
    }
}
