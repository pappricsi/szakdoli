using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class TermekTipus
    {
        [Key]
        public string TipusNev { get; set; }
        public int Mennyiseg { get; set; }
        public virtual List<Termek> Termekek { get; set; }
    }
}
