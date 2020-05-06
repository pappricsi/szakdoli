using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class TermekTipus
    {
        [Key]
        [DisplayName("Azonosító")]
        public int TipusID { get; set; }
        [DisplayName("Típus Név")]
        public string TipusNev { get; set; }
        [DisplayName("Súly")]
        public int Suly { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual List<Termek> Termekek { get; set; }
    }
}
