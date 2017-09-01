using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Migrations
{
    public partial class isdeletednotnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Funcionarios_Contas_ContaId",
                table: "Conta_Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Conta_Funcionarios_ContaId",
                table: "Conta_Funcionarios");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Conta_Funcionarios");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_Funcionarios_Id_conta",
                table: "Conta_Funcionarios",
                column: "Id_conta");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Funcionarios_Contas_Id_conta",
                table: "Conta_Funcionarios",
                column: "Id_conta",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Funcionarios_Contas_Id_conta",
                table: "Conta_Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Conta_Funcionarios_Id_conta",
                table: "Conta_Funcionarios");

            migrationBuilder.AddColumn<Guid>(
                name: "ContaId",
                table: "Conta_Funcionarios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_Funcionarios_ContaId",
                table: "Conta_Funcionarios",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Funcionarios_Contas_ContaId",
                table: "Conta_Funcionarios",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
