using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Elektrodistribucija.Data.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaKwH_jeftina",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "Potrosnja_skupa",
                table: "Racun");

            migrationBuilder.AddColumn<int>(
                name: "CijenaId",
                table: "Racun",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CijenaKwh",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CijenaKwHJeftina = table.Column<decimal>(nullable: false),
                    CijenaKwhSkupa = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CijenaKwh", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Racun_CijenaId",
                table: "Racun",
                column: "CijenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_CijenaKwh_CijenaId",
                table: "Racun",
                column: "CijenaId",
                principalTable: "CijenaKwh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racun_CijenaKwh_CijenaId",
                table: "Racun");

            migrationBuilder.DropTable(
                name: "CijenaKwh");

            migrationBuilder.DropIndex(
                name: "IX_Racun_CijenaId",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "CijenaId",
                table: "Racun");

            migrationBuilder.AddColumn<decimal>(
                name: "CijenaKwH_jeftina",
                table: "Racun",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Potrosnja_skupa",
                table: "Racun",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
