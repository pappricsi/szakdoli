using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Log
    {
        [DisplayName("Azonosító")]
        public int Id { get; set; }
        [DisplayName("Dátum")]
        public DateTime Datum { get; set; }
        [DisplayName("Alkalmaott")]
        public virtual Alkalmazott Letrehozo { get; set; }
        [DisplayName("Leírás")]
        public string Leiras { get; set; }

    }
}
