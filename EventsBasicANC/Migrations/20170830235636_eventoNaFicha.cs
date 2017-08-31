using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Migrations
{
    public partial class eventoNaFicha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id_evento",
                table: "Fichas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_Id_evento",
                table: "Fichas",
                column: "Id_evento");

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_Eventos_Id_evento",
                table: "Fichas",
                column: "Id_evento",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_Eventos_Id_evento",
                table: "Fichas");

            migrationBuilder.DropIndex(
                name: "IX_Fichas_Id_evento",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "Id_evento",
                table: "Fichas");
        }
    }
}
