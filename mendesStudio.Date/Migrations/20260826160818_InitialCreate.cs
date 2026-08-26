using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.Date.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    CodigoAtendimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostoAtendimento = table.Column<int>(type: "int", nullable: false),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.CodigoAtendimento);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento_Procedimentos",
                columns: table => new
                {
                    CodigoAtendimento = table.Column<int>(type: "int", nullable: false),
                    CodigoProcedimento = table.Column<int>(type: "int", nullable: false),
                    PostoAtendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento_Procedimentos", x => new { x.CodigoAtendimento, x.CodigoProcedimento });
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SexoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RgCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos_Cartao",
                columns: table => new
                {
                    CodPagamentoCartao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAtendimento = table.Column<int>(type: "int", nullable: false),
                    NomeCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BandeiraCartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaModificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroVezes = table.Column<int>(type: "int", nullable: false),
                    DebitoCredito = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos_Cartao", x => x.CodPagamentoCartao);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos_Dinheiro",
                columns: table => new
                {
                    CodPagamentoDinheiro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAtendimento = table.Column<int>(type: "int", nullable: false),
                    NomePagador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BancoPagador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos_Dinheiro", x => x.CodPagamentoDinheiro);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos_Pix",
                columns: table => new
                {
                    CodPagamentoPix = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAtendimento = table.Column<int>(type: "int", nullable: false),
                    NomePagador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BancoPagador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos_Pix", x => x.CodPagamentoPix);
                });

            migrationBuilder.CreateTable(
                name: "Postos",
                columns: table => new
                {
                    CodigoPosto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescPosto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContaBancaria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postos", x => x.CodigoPosto);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    CodigoProcedimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorProcedimento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescProcedimento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.CodigoProcedimento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Atendimento_Procedimentos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pagamentos_Cartao");

            migrationBuilder.DropTable(
                name: "Pagamentos_Dinheiro");

            migrationBuilder.DropTable(
                name: "Pagamentos_Pix");

            migrationBuilder.DropTable(
                name: "Postos");

            migrationBuilder.DropTable(
                name: "Procedimentos");
        }
    }
}
