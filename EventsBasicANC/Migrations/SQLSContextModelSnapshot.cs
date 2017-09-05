﻿// <auto-generated />
using EventsBasicANC.Data;
using EventsBasicANC.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace EventsBasicANC.Migrations
{
    [DbContext(typeof(SQLSContext))]
    partial class SQLSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventsBasicANC.Models.Conta", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<Guid?>("Id_Conta_Principal");

                    b.Property<string>("Login");

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("Id_Conta_Principal")
                        .IsUnique()
                        .HasFilter("[Id_Conta_Principal] IS NOT NULL");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Conta_Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Aprovador");

                    b.Property<bool?>("Ativo");

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<Guid>("Id_conta");

                    b.Property<Guid>("Id_funcionario");

                    b.Property<bool?>("Permanente");

                    b.Property<DateTime?>("Vencimento");

                    b.HasKey("Id");

                    b.HasIndex("Id_conta");

                    b.HasIndex("Id_funcionario");

                    b.ToTable("Conta_Funcionarios");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<string>("Documento");

                    b.Property<int>("DocumentoTipo");

                    b.Property<string>("Email");

                    b.Property<string>("EmailAdicional");

                    b.Property<string>("NomeCompleto");

                    b.Property<string>("Telefone");

                    b.Property<string>("Telefone2");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Contrato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Aprovado");

                    b.Property<bool?>("Ativo");

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<DateTime?>("DataAprovacao");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<string>("Descricao");

                    b.Property<Guid>("Id_evento");

                    b.Property<Guid>("Id_loja");

                    b.Property<Guid>("Id_organizador");

                    b.Property<DateTime?>("Vencimento");

                    b.HasKey("Id");

                    b.HasIndex("Id_evento");

                    b.HasIndex("Id_loja");

                    b.HasIndex("Id_organizador");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Cor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<string>("CorFromHex");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Cores");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<string>("Estado");

                    b.Property<string>("Numero");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<bool?>("Cancelado");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<DateTime?>("DataFim");

                    b.Property<DateTime?>("DataInicio");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<string>("Descricao");

                    b.Property<Guid>("Id_organizador");

                    b.HasKey("Id");

                    b.HasIndex("Id_organizador");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Ficha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<string>("Codigo");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<Guid>("Id_evento");

                    b.Property<string>("NomeCliente");

                    b.Property<double>("Saldo");

                    b.HasKey("Id");

                    b.HasIndex("Id_evento");

                    b.ToTable("Fichas");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Movimentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<DateTime?>("Data");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<Guid?>("Id_Pagamento");

                    b.Property<Guid>("Id_ficha");

                    b.Property<int>("MovimentacaoTipo");

                    b.Property<string>("Observacao");

                    b.Property<double?>("SaldoAnterior");

                    b.Property<double?>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("Id_Pagamento");

                    b.HasIndex("Id_ficha");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Pagamento", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<bool?>("Cancelado");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<double?>("Total");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Pagamento_Ficha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<Guid>("Id_ficha");

                    b.Property<Guid>("Id_pagamento");

                    b.Property<double?>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("Id_ficha");

                    b.HasIndex("Id_pagamento");

                    b.ToTable("Pagamento_Fichas");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<string>("Descricao");

                    b.Property<Guid?>("Id_Cor");

                    b.Property<Guid>("Id_loja");

                    b.Property<double?>("Preco");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("Id_Cor");

                    b.HasIndex("Id_loja");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Venda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<bool>("Cancelada");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<DateTime>("Data");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<Guid>("Id_Evento");

                    b.Property<Guid>("Id_loja");

                    b.Property<double?>("Total");

                    b.HasKey("Id");

                    b.HasIndex("Id_Evento");

                    b.HasIndex("Id_loja");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Venda_Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

                    b.Property<Guid>("Id_produto");

                    b.Property<Guid>("Id_venda");

                    b.Property<int>("Quantidade");

                    b.Property<double>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("Id_produto");

                    b.HasIndex("Id_venda");

                    b.ToTable("Venda_Produtos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Regra");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Regra_Claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("Usuario_Regra");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Usuario", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");


                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Usuario");

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("EventsBasicANC.Models.Conta", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Contato", "Contato")
                        .WithOne("Conta")
                        .HasForeignKey("EventsBasicANC.Models.Conta", "Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsBasicANC.Models.Endereco", "Endereco")
                        .WithOne("Conta")
                        .HasForeignKey("EventsBasicANC.Models.Conta", "Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsBasicANC.Models.Conta", "Conta_Principal")
                        .WithOne()
                        .HasForeignKey("EventsBasicANC.Models.Conta", "Id_Conta_Principal")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Conta_Funcionario", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Conta", "Conta")
                        .WithMany("Funcionario_Contas")
                        .HasForeignKey("Id_conta")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsBasicANC.Models.Conta", "Funcionario")
                        .WithMany("Conta_Funcionarios")
                        .HasForeignKey("Id_funcionario")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Contrato", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Evento", "Evento")
                        .WithMany("Contratos")
                        .HasForeignKey("Id_evento")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsBasicANC.Models.Conta", "Loja")
                        .WithMany("Loja_Contratos")
                        .HasForeignKey("Id_loja")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsBasicANC.Models.Conta", "Organizador")
                        .WithMany("Organizador_Contratos")
                        .HasForeignKey("Id_organizador")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Evento", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Conta", "Organizador")
                        .WithMany("Eventos")
                        .HasForeignKey("Id_organizador")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Ficha", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Evento", "Evento")
                        .WithMany("Fichas")
                        .HasForeignKey("Id_evento")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Movimentacao", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Pagamento", "Pagamento")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("Id_Pagamento");

                    b.HasOne("EventsBasicANC.Models.Ficha", "Ficha")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("Id_ficha")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Pagamento", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Venda", "Venda")
                        .WithOne("Pagamento")
                        .HasForeignKey("EventsBasicANC.Models.Pagamento", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Pagamento_Ficha", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Ficha", "Ficha")
                        .WithMany("Pagamento_Fichas")
                        .HasForeignKey("Id_ficha")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsBasicANC.Models.Pagamento", "Pagamento")
                        .WithMany("Pagamento_Fichas")
                        .HasForeignKey("Id_pagamento")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Produto", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Cor", "Cor")
                        .WithMany("Produtos")
                        .HasForeignKey("Id_Cor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsBasicANC.Models.Conta", "Loja")
                        .WithMany("Produtos")
                        .HasForeignKey("Id_loja")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Venda", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Evento", "Evento")
                        .WithMany("Vendas")
                        .HasForeignKey("Id_Evento")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsBasicANC.Models.Conta", "Conta")
                        .WithMany("Vendas")
                        .HasForeignKey("Id_loja")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventsBasicANC.Models.Venda_Produto", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Produto", "Produto")
                        .WithMany("Venda_Produtos")
                        .HasForeignKey("Id_produto")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsBasicANC.Models.Venda", "Venda")
                        .WithMany("Venda_Produtos")
                        .HasForeignKey("Id_venda")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsBasicANC.Models.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EventsBasicANC.Models.Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
