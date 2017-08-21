using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventsBasicANC.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorFromHex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fichas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regra",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento_Fichas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_ficha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento_Fichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Fichas_Fichas_Id_ficha",
                        column: x => x.Id_ficha,
                        principalTable: "Fichas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regra_Claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regra_Claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regra_Claim_Regra_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Regra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claim_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Login_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Token_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Regra",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Regra", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Usuario_Regra_Regra_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Regra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Regra_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoTipo = table.Column<int>(type: "int", nullable: false),
                    Id_Conta_Principal = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Contatos_Id",
                        column: x => x.Id,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_Enderecos_Id",
                        column: x => x.Id,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conta_Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aprovador = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_conta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_funcionario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Permanente = table.Column<bool>(type: "bit", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conta_Funcionarios_Contas_Id_funcionario",
                        column: x => x.Id_funcionario,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_organizador = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Contas_Id_organizador",
                        column: x => x.Id_organizador,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Cor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_loja = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Cores_Id_Cor",
                        column: x => x.Id_Cor,
                        principalTable: "Cores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Contas_Id_loja",
                        column: x => x.Id_loja,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aprovado = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAprovacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_evento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_loja = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_organizador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Eventos_Id_evento",
                        column: x => x.Id_evento,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Contas_Id_loja",
                        column: x => x.Id_loja,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Contas_Id_organizador",
                        column: x => x.Id_organizador,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelada = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Evento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_loja = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Eventos_Id_Evento",
                        column: x => x.Id_Evento,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Contas_Id_loja",
                        column: x => x.Id_loja,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_venda = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Vendas_Id_venda",
                        column: x => x.Id_venda,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venda_Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_produto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_venda = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Produtos_Produtos_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_Produtos_Vendas_Id_venda",
                        column: x => x.Id_venda,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Pagamento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_ficha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovimentacaoTipo = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaldoAnterior = table.Column<double>(type: "float", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Pagamentos_Id_Pagamento",
                        column: x => x.Id_Pagamento,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Fichas_Id_ficha",
                        column: x => x.Id_ficha,
                        principalTable: "Fichas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claim_UserId",
                table: "Claim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_Funcionarios_Id_funcionario",
                table: "Conta_Funcionarios",
                column: "Id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Id_Conta_Principal",
                table: "Contas",
                column: "Id_Conta_Principal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Id_evento",
                table: "Contratos",
                column: "Id_evento");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Id_loja",
                table: "Contratos",
                column: "Id_loja");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Id_organizador",
                table: "Contratos",
                column: "Id_organizador");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_Id_organizador",
                table: "Eventos",
                column: "Id_organizador");

            migrationBuilder.CreateIndex(
                name: "IX_Login_UserId",
                table: "Login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Id_Pagamento",
                table: "Movimentacoes",
                column: "Id_Pagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Id_ficha",
                table: "Movimentacoes",
                column: "Id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_Fichas_Id_ficha",
                table: "Pagamento_Fichas",
                column: "Id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_Id_venda",
                table: "Pagamentos",
                column: "Id_venda");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Id_Cor",
                table: "Produtos",
                column: "Id_Cor");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Id_loja",
                table: "Produtos",
                column: "Id_loja");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Regra",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Regra_Claim_RoleId",
                table: "Regra_Claim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Usuario",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Usuario",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Regra_RoleId",
                table: "Usuario_Regra",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Produtos_Id_produto",
                table: "Venda_Produtos",
                column: "Id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Produtos_Id_venda",
                table: "Venda_Produtos",
                column: "Id_venda");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Id_Evento",
                table: "Vendas",
                column: "Id_Evento");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Id_loja",
                table: "Vendas",
                column: "Id_loja");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Conta_Funcionarios_Id_Conta_Principal",
                table: "Contas",
                column: "Id_Conta_Principal",
                principalTable: "Conta_Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Funcionarios_Contas_Id_funcionario",
                table: "Conta_Funcionarios");

            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Pagamento_Fichas");

            migrationBuilder.DropTable(
                name: "Regra_Claim");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Usuario_Regra");

            migrationBuilder.DropTable(
                name: "Venda_Produtos");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Fichas");

            migrationBuilder.DropTable(
                name: "Regra");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Conta_Funcionarios");
        }
    }
}
