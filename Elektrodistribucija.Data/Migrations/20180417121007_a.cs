using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Elektrodistribucija.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oprema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oprema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipKvara",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKvara", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivUloge = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Direkcija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direkcija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direkcija_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klijenti_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    UlogaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KorisnickiNalog_Uloge_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odjel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    DirekcijaID = table.Column<int>(nullable: false),
                    Svrha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odjel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odjel_Direkcija_DirekcijaID",
                        column: x => x.DirekcijaID,
                        principalTable: "Direkcija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prikljucak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    DatumPrikljucenja = table.Column<DateTime>(nullable: false),
                    GradID = table.Column<int>(nullable: false),
                    KlijentID = table.Column<int>(nullable: true),
                    Parcela = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prikljucak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prikljucak_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prikljucak_Klijenti_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    KlijentID = table.Column<int>(nullable: false),
                    TipZahtjeva = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Klijenti_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutorizacijaToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IpAdresa = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: false),
                    Vrijednost = table.Column<string>(nullable: true),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacijaToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutorizacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bonus = table.Column<decimal>(nullable: false),
                    KorisnickiNalogId = table.Column<int>(nullable: true),
                    Osnovica = table.Column<decimal>(nullable: false),
                    Ukupno = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plata_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReferentKlijenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferentKlijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferentKlijenti_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReferentNabavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferentNabavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferentNabavke_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Serviser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serviser_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brojilo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    PrikljucakID = table.Column<int>(nullable: false),
                    StaroStanjeJeftina = table.Column<decimal>(nullable: false),
                    StaroStanjeSkupa = table.Column<decimal>(nullable: false),
                    TrenutnoStanjeJeftina = table.Column<decimal>(nullable: false),
                    TrenutnoStanjeSkupa = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brojilo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brojilo_Prikljucak_PrikljucakID",
                        column: x => x.PrikljucakID,
                        principalTable: "Prikljucak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavjestenja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    PrikljucakID = table.Column<int>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavjestenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obavjestenja_Prikljucak_PrikljucakID",
                        column: x => x.PrikljucakID,
                        principalTable: "Prikljucak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opomena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    PrikljucakID = table.Column<int>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opomena", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opomena_Prikljucak_PrikljucakID",
                        column: x => x.PrikljucakID,
                        principalTable: "Prikljucak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrijavaKvara",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    PrikljucakID = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    TipKvaraID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaKvara", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrijavaKvara_Prikljucak_PrikljucakID",
                        column: x => x.PrikljucakID,
                        principalTable: "Prikljucak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrijavaKvara_TipKvara_TipKvaraID",
                        column: x => x.TipKvaraID,
                        principalTable: "TipKvara",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivremenoIskljucenje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    PrikljucakID = table.Column<int>(nullable: false),
                    Razlog = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivremenoIskljucenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivremenoIskljucenje_Prikljucak_PrikljucakID",
                        column: x => x.PrikljucakID,
                        principalTable: "Prikljucak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<decimal>(nullable: false),
                    PrikljucakID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplata_Prikljucak_PrikljucakID",
                        column: x => x.PrikljucakID,
                        principalTable: "Prikljucak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojiloID = table.Column<int>(nullable: false),
                    CijenaKwH_jeftina = table.Column<decimal>(nullable: false),
                    CijenaKwH_skupa = table.Column<decimal>(nullable: false),
                    Dug = table.Column<decimal>(nullable: false),
                    Mjesec = table.Column<string>(nullable: true),
                    Potrosnja_jeftina = table.Column<decimal>(nullable: false),
                    Potrosnja_skupa = table.Column<decimal>(nullable: false),
                    Ukupno = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racun_Brojilo_BrojiloID",
                        column: x => x.BrojiloID,
                        principalTable: "Brojilo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intervencija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alati = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Lokacija = table.Column<string>(nullable: true),
                    OpremaID = table.Column<int>(nullable: false),
                    PrijavaKvaraID = table.Column<int>(nullable: false),
                    ServiserID = table.Column<int>(nullable: false),
                    Trajanje = table.Column<string>(nullable: true),
                    Troskovi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervencija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intervencija_Oprema_OpremaID",
                        column: x => x.OpremaID,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intervencija_PrijavaKvara_PrijavaKvaraID",
                        column: x => x.PrijavaKvaraID,
                        principalTable: "PrijavaKvara",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intervencija_Serviser_ServiserID",
                        column: x => x.ServiserID,
                        principalTable: "Serviser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_KorisnickiNalogId",
                table: "Administrator",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacijaToken_KorisnickiNalogId",
                table: "AutorizacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Brojilo_PrikljucakID",
                table: "Brojilo",
                column: "PrikljucakID");

            migrationBuilder.CreateIndex(
                name: "IX_Direkcija_GradID",
                table: "Direkcija",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencija_OpremaID",
                table: "Intervencija",
                column: "OpremaID");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencija_PrijavaKvaraID",
                table: "Intervencija",
                column: "PrijavaKvaraID");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencija_ServiserID",
                table: "Intervencija",
                column: "ServiserID");

            migrationBuilder.CreateIndex(
                name: "IX_Klijenti_GradID",
                table: "Klijenti",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalog_UlogaID",
                table: "KorisnickiNalog",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavjestenja_PrikljucakID",
                table: "Obavjestenja",
                column: "PrikljucakID");

            migrationBuilder.CreateIndex(
                name: "IX_Odjel_DirekcijaID",
                table: "Odjel",
                column: "DirekcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Opomena_PrikljucakID",
                table: "Opomena",
                column: "PrikljucakID");

            migrationBuilder.CreateIndex(
                name: "IX_Plata_KorisnickiNalogId",
                table: "Plata",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaKvara_PrikljucakID",
                table: "PrijavaKvara",
                column: "PrikljucakID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaKvara_TipKvaraID",
                table: "PrijavaKvara",
                column: "TipKvaraID");

            migrationBuilder.CreateIndex(
                name: "IX_Prikljucak_GradID",
                table: "Prikljucak",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Prikljucak_KlijentID",
                table: "Prikljucak",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_PrivremenoIskljucenje_PrikljucakID",
                table: "PrivremenoIskljucenje",
                column: "PrikljucakID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_BrojiloID",
                table: "Racun",
                column: "BrojiloID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferentKlijenti_KorisnickiNalogId",
                table: "ReferentKlijenti",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferentNabavke_KorisnickiNalogId",
                table: "ReferentNabavke",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Serviser_KorisnickiNalogId",
                table: "Serviser",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_PrikljucakID",
                table: "Uplata",
                column: "PrikljucakID");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_KlijentID",
                table: "Zahtjev",
                column: "KlijentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "AutorizacijaToken");

            migrationBuilder.DropTable(
                name: "Intervencija");

            migrationBuilder.DropTable(
                name: "Obavjestenja");

            migrationBuilder.DropTable(
                name: "Odjel");

            migrationBuilder.DropTable(
                name: "Opomena");

            migrationBuilder.DropTable(
                name: "Plata");

            migrationBuilder.DropTable(
                name: "PrivremenoIskljucenje");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "ReferentKlijenti");

            migrationBuilder.DropTable(
                name: "ReferentNabavke");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "Oprema");

            migrationBuilder.DropTable(
                name: "PrijavaKvara");

            migrationBuilder.DropTable(
                name: "Serviser");

            migrationBuilder.DropTable(
                name: "Direkcija");

            migrationBuilder.DropTable(
                name: "Brojilo");

            migrationBuilder.DropTable(
                name: "TipKvara");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Prikljucak");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Klijenti");

            migrationBuilder.DropTable(
                name: "Grad");
        }
    }
}
