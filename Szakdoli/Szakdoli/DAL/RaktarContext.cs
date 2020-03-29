using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Szakdoli.Models;

namespace Szakdoli.DAL
{
    public class RaktarContext : IdentityDbContext<Alkalmazott>
    {
        
        public RaktarContext(DbContextOptions<RaktarContext> options) : base (options)
        {

        }

        
        public DbSet<Log> Logok { get; set; }
        public DbSet<Lokacio> Lokaciok { get; set; }
        public DbSet<Raktar> Raktarak { get; set; }
        public DbSet<Termek> Termekek { get; set; }
        public DbSet<TermekTipus> TermekTipusok { get; set; }
        public DbSet<Alkalmazott> Alkalmazottak { get; set; }
        public DbSet<Keszlet> Keszlet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Raktar>()
            .HasMany(c => c.Alkalmazottak)
            .WithOne(e => e.Raktar).OnDelete(DeleteBehavior.NoAction);

            
            
            base.OnModelCreating(modelBuilder);

        }


    }
}
