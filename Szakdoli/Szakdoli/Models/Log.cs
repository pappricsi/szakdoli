using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public virtual Alkalmazott Letrehozo { get; set; }
        public string Leiras { get; set; }

    }
}
