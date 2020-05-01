using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Keszlet
    {
        [Key]
        [DisplayName("Azonosító")]
        public int Id { get; set; }
        [ForeignKey("Tipus")]
        public int TermekTipusId { get; set; }
        [DisplayName("Termék típus")]
        public virtual TermekTipus TermekTipus { get; set; }
        [ForeignKey("keszlete")]
        public int RaktarId { get; set; }
        [DisplayName("Telephely")]
        public Raktar Raktar { get; set; }
        [DisplayName("Mennyiség")]
        public int Mennyiseg { get; set; }
    }
}
