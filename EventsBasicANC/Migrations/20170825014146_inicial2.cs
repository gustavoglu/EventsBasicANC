using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Vendas_Id_venda",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_Id_venda",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "Id_venda",
                table: "Pagamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Vendas_Id",
                table: "Pagamentos",
                column: "Id",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Vendas_Id",
                table: "Pagamentos");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_venda",
                table: "Pagamentos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_Id_venda",
                table: "Pagamentos",
                column: "Id_venda");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Vendas_Id_venda",
                table: "Pagamentos",
                column: "Id_venda",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
