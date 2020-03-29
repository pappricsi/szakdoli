using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Szakdoli.Models;

namespace Szakdoli.DAL
{
    public class DbInitializer
    {
        public static void Initialize(RaktarContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Alkalmazottak.Any())
            {
                return;   // DB has been seeded
            }





            //var raktarak = new Raktar[]
            //{
            //new Raktar{Cim="ProbaCim1", Nev="Egyes Raktar", TelefonSZam="012345678901"},
            //new Raktar{Cim="ProbaCim2", Nev="Kettes Raktar", TelefonSZam="012345678901"},
            //new Raktar{Cim="ProbaCim3", Nev="Harmas Raktar", TelefonSZam="012345678901"},
            //};
            //foreach (Raktar ra in raktarak)
            //{
            //    context.Raktarak.Add(ra);
            //}
            //context.SaveChanges();


            // var alkalmazottak = new Alkalmazott[]
            //{
            // new Alkalmazott{TeljesNev="Proba Pista",},
            // new Alkalmazott{TeljesNev="Proba Jani",},
            // new Alkalmazott{TeljesNev="Proba Béla",},
            //};
            // foreach (Alkalmazott a in alkalmazottak)
            // {
            //     context.Alkalmazottak.Add(a);
            // }
            // context.SaveChanges();


            //    var lokaciok = new Lokacio[]
            //   {
            //    new Lokacio{LokacioNev="egyes", },
            //    new Lokacio{LokacioNev="kettes",},
            //    new Lokacio{LokacioNev="harmas",},
            //    new Lokacio{LokacioNev="negyes",},
            //    new Lokacio{LokacioNev="otos",},
            //    new Lokacio{LokacioNev="hatos",},
            //    new Lokacio{LokacioNev="hetes",},
            //   };
            //    foreach (Lokacio lo in lokaciok)
            //    {
            //        context.Lokaciok.Add(lo);
            //    }
            //    context.SaveChanges();
        }
    }
}
