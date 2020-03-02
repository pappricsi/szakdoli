using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Keszlet
    {
        public int Id { get; set; }
        [ForeignKey("Tipus")]
        public string TermekTipusId { get; set; }
        public virtual TermekTipus TermekTipus { get; set; }
        [ForeignKey("keszlete")]
        public int RaktarId { get; set; }
        public Raktar Raktar { get; set; }

        public int Mennyiseg { get; set; }
    }
}
