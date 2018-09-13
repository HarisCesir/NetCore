using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Elektrodistribucija.Data.Migrations
{
    public partial class cijena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racun_CijenaKwh_CijenaId",
                table: "Racun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CijenaKwh",
                table: "CijenaKwh");

            migrationBuilder.RenameTable(
                name: "CijenaKwh",
                newName: "Cijena");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cijena",
                table: "Cijena",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Cijena_CijenaId",
                table: "Racun",
                column: "CijenaId",
                principalTable: "Cijena",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Cijena_CijenaId",
                table: "Racun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cijena",
                table: "Cijena");

            migrationBuilder.RenameTable(
                name: "Cijena",
                newName: "CijenaKwh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CijenaKwh",
                table: "CijenaKwh",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_CijenaKwh_CijenaId",
                table: "Racun",
                column: "CijenaId",
                principalTable: "CijenaKwh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
