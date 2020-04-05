using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Raktar
    {
        [Key]
        [DisplayName("Azonosító")]
        public int RaktarId { get; set; }
        [DisplayName("Megnevezés")]
        public string Nev { get; set; }
        [DisplayName("Cím")]
        public string Cim { get; set; }
        [DisplayName("Tel. Szám")]
        public string TelefonSZam { get; set; }
        //public string Vezeto { get; set; }
        public  List<Lokacio> Lokaciok { get; set; }
        public  ICollection<Alkalmazott> Alkalmazottak { get; set; }

    }
}
