using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Elektrodistribucija.Data.Migrations
{
    public partial class dug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uplata_Prikljucak_PrikljucakID",
                table: "Uplata");

            migrationBuilder.RenameColumn(
                name: "PrikljucakID",
                table: "Uplata",
                newName: "BrojiloID");

            migrationBuilder.RenameIndex(
                name: "IX_Uplata_PrikljucakID",
                table: "Uplata",
                newName: "IX_Uplata_BrojiloID");

            migrationBuilder.AddColumn<decimal>(
                name: "Ukupno",
                table: "Dugovanja",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Uplata_Brojilo_BrojiloID",
                table: "Uplata",
                column: "BrojiloID",
                principalTable: "Brojilo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uplata_Brojilo_BrojiloID",
                table: "Uplata");

            migrationBuilder.DropColumn(
                name: "Ukupno",
                table: "Dugovanja");

            migrationBuilder.RenameColumn(
                name: "BrojiloID",
                table: "Uplata",
                newName: "PrikljucakID");

            migrationBuilder.RenameIndex(
                name: "IX_Uplata_BrojiloID",
                table: "Uplata",
                newName: "IX_Uplata_PrikljucakID");

            migrationBuilder.AddForeignKey(
                name: "FK_Uplata_Prikljucak_PrikljucakID",
                table: "Uplata",
                column: "PrikljucakID",
                principalTable: "Prikljucak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
