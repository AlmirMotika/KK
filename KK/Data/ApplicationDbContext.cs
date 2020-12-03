using System;
using System.Collections.Generic;
using System.Text;
using KK.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KK.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Drzava> Drzavas { get; set; }
        public DbSet<Grad> Grads { get; set; }
        public DbSet<Karta> Kartas { get; set; }
        public DbSet<Linija> Linijas { get; set; }
        public DbSet<Radnik> Radniks { get; set; }
        public DbSet<Radnik_Kvalifikacija> Radnik_Kvalifikacijas { get; set; }
        public DbSet<Tip_Linije> Tip_Linijes { get; set; }
        public DbSet<Tip_Vozila> Tip_Vozilas { get; set; }
        public DbSet<Vozilo> Vozilos { get; set; }
        public DbSet<Voznja> Voznjas { get; set; }
        public DbSet<Obavijest> Obavijests { get; set; }
        public DbSet<Prodaja> Prodaje { get; set; }
    }
}
