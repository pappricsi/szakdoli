using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    public class Alkalmazott : IdentityUser
    {
        public string TeljesNev { get; set; }
        [ForeignKey("telephely")]
        public int RaktarID { get; set; }
        public  Raktar Raktar { get; set; }
    }

    
}
