using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Lokacio
    {
        [Key]
        [DisplayName("Azonosító")]
        public int LokacioId { get; set; }
        [DisplayName("Megnevezés")]
        public string LokacioNev { get; set; }
        [ForeignKey("Raktar")]
        [DisplayName("Telephely")]
        public int RaktarID { get; set; }
        [DisplayName("Telephely")]
        public virtual Raktar Raktar { get; set; }
        [DisplayName("Foglalt")]
        public bool Foglalt { get; set; }

        public virtual Termek Termek { get; set; }
    }
}
