using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Azonosító")]
        public int TermekID { get; set; }
        [ForeignKey("Helye")]
        [DisplayName("Tárhely")]
        public int LokacioId { get; set; }
        [DisplayName("Tárhely")]
        public virtual Lokacio Lokacio { get; set; }
        [ForeignKey("Tipus")]
        [DisplayName("Termék típus")]
        public int TermekTipusId { get; set; }
        [DisplayName("Típus")]
        public virtual TermekTipus Tipus { get; set; }
        [DisplayName("Betárolva")]
        public DateTime Betarazva { get; set; }
    }
}
