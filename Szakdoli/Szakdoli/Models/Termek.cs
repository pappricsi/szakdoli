using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Termek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TermekID { get; set; }
        [ForeignKey("Helye")]
        public int LokacioId { get; set; }
        public virtual Lokacio Lokacio { get; set; }
        [ForeignKey("Tipus")]
        public int TermekTipusId { get; set; }
        public virtual TermekTipus Tipus { get; set; }
        public DateTime Betarazva { get; set; }
    }
}
