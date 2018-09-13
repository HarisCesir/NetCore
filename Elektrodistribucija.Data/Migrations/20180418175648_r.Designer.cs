﻿// <auto-generated />
using Elektrodistribucija.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Elektrodistribucija.Data.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20180418175648_r")]
    partial class r
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Elektrodistribucija.Data.EntityModels.AutorizacijaToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IpAdresa");

                    b.Property<int>("KorisnickiNalogId");

                    b.Property<string>("Vrijednost");

                    b.Property<DateTime>("VrijemeEvidentiranja");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutorizacijaToken");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Brojilo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("PrikljucakID");

                    b.Property<decimal>("StaroStanjeJeftina");

                    b.Property<decimal>("StaroStanjeSkupa");

                    b.Property<decimal>("TrenutnoStanjeJeftina");

                    b.Property<decimal>("TrenutnoStanjeSkupa");

                    b.HasKey("Id");

                    b.HasIndex("PrikljucakID");

                    b.ToTable("Brojilo");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.CijenaKwh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CijenaKwHJeftina");

                    b.Property<decimal>("CijenaKwhSkupa");

                    b.HasKey("Id");

                    b.ToTable("Cijena");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Direkcija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<int>("GradID");

                    b.HasKey("Id");

                    b.HasIndex("GradID");

                    b.ToTable("Direkcija");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Dugovanja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("RacuniUkupno");

                    b.Property<decimal>("Uplata");

                    b.HasKey("Id");

                    b.ToTable("Dugovanja");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<string>("PostanskiBroj");

                    b.HasKey("Id");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Intervencija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alati");

                    b.Property<DateTime>("Datum");

                    b.Property<string>("Lokacija");

                    b.Property<int>("OpremaID");

                    b.Property<int>("PrijavaKvaraID");

                    b.Property<int>("ServiserID");

                    b.Property<string>("Trajanje");

                    b.Property<string>("Troskovi");

                    b.HasKey("Id");

                    b.HasIndex("OpremaID");

                    b.HasIndex("PrijavaKvaraID");

                    b.HasIndex("ServiserID");

                    b.ToTable("Intervencija");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Klijenti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<int>("GradID");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("GradID");

                    b.ToTable("Klijenti");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.Property<int?>("UlogaID");

                    b.HasKey("Id");

                    b.HasIndex("UlogaID");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Odjel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<int>("DirekcijaID");

                    b.Property<string>("Svrha");

                    b.HasKey("Id");

                    b.HasIndex("DirekcijaID");

                    b.ToTable("Odjel");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Opomena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("PrikljucakID");

                    b.Property<string>("Sadrzaj");

                    b.HasKey("Id");

                    b.HasIndex("PrikljucakID");

                    b.ToTable("Opomena");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Oprema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Oprema");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Plata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Bonus");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<decimal>("Osnovica");

                    b.Property<decimal>("Ukupno");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("Plata");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.PrijavaKvara", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<string>("Opis");

                    b.Property<int?>("PrikljucakID");

                    b.Property<bool>("Status");

                    b.Property<int>("TipKvaraID");

                    b.HasKey("Id");

                    b.HasIndex("PrikljucakID");

                    b.HasIndex("TipKvaraID");

                    b.ToTable("PrijavaKvara");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Prikljucak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<DateTime>("DatumPrikljucenja");

                    b.Property<int>("GradID");

                    b.Property<int?>("KlijentID");

                    b.Property<string>("Parcela");

                    b.HasKey("Id");

                    b.HasIndex("GradID");

                    b.HasIndex("KlijentID");

                    b.ToTable("Prikljucak");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.PrivremenoIskljucenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("PrikljucakID");

                    b.Property<string>("Razlog");

                    b.HasKey("Id");

                    b.HasIndex("PrikljucakID");

                    b.ToTable("PrivremenoIskljucenje");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Racun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojiloID");

                    b.Property<int>("CijenaId");

                    b.Property<decimal>("Dug");

                    b.Property<string>("Mjesec");

                    b.Property<decimal>("Potrosnja_Skupa");

                    b.Property<decimal>("Potrosnja_jeftina");

                    b.Property<decimal>("Ukupno");

                    b.HasKey("Id");

                    b.HasIndex("BrojiloID");

                    b.HasIndex("CijenaId");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.ReferentKlijenti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("ReferentKlijenti");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Serviser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<int?>("KorisnickiNalogId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("Serviser");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.TipKvara", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("TipKvara");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Uloge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NazivUloge");

                    b.HasKey("Id");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Uplata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<decimal>("Iznos");

                    b.Property<int>("PrikljucakID");

                    b.HasKey("Id");

                    b.HasIndex("PrikljucakID");

                    b.ToTable("Uplata");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.EntityModels.AutorizacijaToken", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Administrator", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Brojilo", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Prikljucak", "Prikljucak")
                        .WithMany()
                        .HasForeignKey("PrikljucakID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Direkcija", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Intervencija", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Oprema", "Oprema")
                        .WithMany()
                        .HasForeignKey("OpremaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elektrodistribucija.Data.Models.PrijavaKvara", "PrijavaKvara")
                        .WithMany()
                        .HasForeignKey("PrijavaKvaraID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elektrodistribucija.Data.Models.Serviser", "Serviser")
                        .WithMany()
                        .HasForeignKey("ServiserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Klijenti", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.KorisnickiNalog", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Uloge", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaID");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Odjel", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Direkcija", "Direkcija")
                        .WithMany()
                        .HasForeignKey("DirekcijaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Opomena", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Prikljucak", "Prikljucak")
                        .WithMany()
                        .HasForeignKey("PrikljucakID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Plata", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.PrijavaKvara", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Prikljucak", "Prikljucak")
                        .WithMany()
                        .HasForeignKey("PrikljucakID");

                    b.HasOne("Elektrodistribucija.Data.Models.TipKvara", "TipKvara")
                        .WithMany()
                        .HasForeignKey("TipKvaraID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Prikljucak", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elektrodistribucija.Data.Models.Klijenti", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentID");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.PrivremenoIskljucenje", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Prikljucak", "Prikljucak")
                        .WithMany()
                        .HasForeignKey("PrikljucakID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Racun", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Brojilo", "Brojilo")
                        .WithMany()
                        .HasForeignKey("BrojiloID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Elektrodistribucija.Data.Models.CijenaKwh", "Cijena")
                        .WithMany()
                        .HasForeignKey("CijenaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.ReferentKlijenti", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Serviser", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId");
                });

            modelBuilder.Entity("Elektrodistribucija.Data.Models.Uplata", b =>
                {
                    b.HasOne("Elektrodistribucija.Data.Models.Prikljucak", "Prikljucak")
                        .WithMany()
                        .HasForeignKey("PrikljucakID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
