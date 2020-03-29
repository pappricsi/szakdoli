using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Raktar
    {
        [Key]
        public int RaktarId { get; set; }
        public string Nev { get; set; }
        public string Cim { get; set; }
        public string TelefonSZam { get; set; }
        //public string Vezeto { get; set; }
        public  List<Lokacio> Lokaciok { get; set; }
        public  ICollection<Alkalmazott> Alkalmazottak { get; set; }

    }
}
