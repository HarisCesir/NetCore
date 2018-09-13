using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Elektrodistribucija.Data.Migrations
{
    public partial class r : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CijenaKwH_skupa",
                table: "Racun",
                newName: "Potrosnja_Skupa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Potrosnja_Skupa",
                table: "Racun",
                newName: "CijenaKwH_skupa");
        }
    }
}
