using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Lokacio
    {
        [Key]
        public int LokacioId { get; set; }
        public string LokacioNev { get; set; }
        [ForeignKey("Raktar")]
        public int RaktarID { get; set; }
        public virtual Raktar Raktar { get; set; }

        public bool Foglalt { get; set; }

        public virtual Termek Termek { get; set; }
    }
}
