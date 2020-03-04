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
        public int TipusID { get; set; }
        public string TipusNev { get; set; }
        public int Suly { get; set; }
        public virtual List<Termek> Termekek { get; set; }
    }
}
