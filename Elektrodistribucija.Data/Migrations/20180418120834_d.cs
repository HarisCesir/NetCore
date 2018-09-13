using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Elektrodistribucija.Data.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obavjestenja");

            migrationBuilder.CreateTable(
                name: "Dugovanja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RacuniUkupno = table.Column<decimal>(nullable: false),
                    Uplata = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dugovanja", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dugovanja");

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

            migrationBuilder.CreateIndex(
                name: "IX_Obavjestenja_PrikljucakID",
                table: "Obavjestenja",
                column: "PrikljucakID");
        }
    }
}
