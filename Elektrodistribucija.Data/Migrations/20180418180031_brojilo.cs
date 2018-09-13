using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Elektrodistribucija.Data.Migrations
{
    public partial class brojilo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojiloID",
                table: "Dugovanja",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dugovanja_BrojiloID",
                table: "Dugovanja",
                column: "BrojiloID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dugovanja_Brojilo_BrojiloID",
                table: "Dugovanja",
                column: "BrojiloID",
                principalTable: "Brojilo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dugovanja_Brojilo_BrojiloID",
                table: "Dugovanja");

            migrationBuilder.DropIndex(
                name: "IX_Dugovanja_BrojiloID",
                table: "Dugovanja");

            migrationBuilder.DropColumn(
                name: "BrojiloID",
                table: "Dugovanja");
        }
    }
}
