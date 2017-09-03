using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Migrations
{
    public partial class cascateConta1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Contas_Id_organizador",
                table: "Eventos");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Contas_Id_organizador",
                table: "Eventos",
                column: "Id_organizador",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Contas_Id_organizador",
                table: "Eventos");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Contas_Id_organizador",
                table: "Eventos",
                column: "Id_organizador",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
