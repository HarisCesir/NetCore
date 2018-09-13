using Elektrodistribucija.Data.EntityModels;
using Elektrodistribucija.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Elektrodistribucija.Data.DAL
{
    public class MojContext : DbContext
    {
        public MojContext(DbContextOptions<MojContext> options) : base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


          //  modelBuilder.Entity<Administrator>().HasOne(x => x.KorisnickiNalog);


        }



        public DbSet<Odjel> Odjel { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Klijenti> Klijenti { get; set; }
        public DbSet<Direkcija> Direkcija { get; set; }

        public DbSet<Brojilo> Brojilo { get; set; }

        public DbSet<Intervencija> Intervencija { get; set; }

       

        public DbSet<Opomena> Opomena { get; set; }

        public DbSet<Oprema> Oprema { get; set; }

        public DbSet<Plata> Plata { get; set; }

        public DbSet<PrijavaKvara> PrijavaKvara { get; set; }

        public DbSet<Prikljucak> Prikljucak { get; set; }
        public DbSet<PrivremenoIskljucenje> PrivremenoIskljucenje { get; set; }

        public DbSet<Racun> Racun { get; set; }

        public DbSet<TipKvara> TipKvara { get; set; }

        public DbSet<Uplata> Uplata { get; set; }

        

        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Uloge> Uloge { get; set; }

        public DbSet<Serviser> Serviser { get; set; }
        public DbSet<ReferentKlijenti> ReferentKlijenti { get; set; }
       
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<AutorizacijaToken> AutorizacijaToken { get; set; }
        public DbSet<Dugovanja> Dugovanja { get; set; }
        public DbSet<CijenaKwh> Cijena { get; set; }

    }
}