using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Migrations
{
    public partial class alteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "DocumentoTipo",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Contas");

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentoTipo",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeCompleto",
                table: "Contatos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeCompleto",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "DocumentoTipo",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "NomeCompleto",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "NomeCompleto",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "Contas");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Enderecos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Contas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Contas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentoTipo",
                table: "Contas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Contas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Contas",
                nullable: true);
        }
    }
}
