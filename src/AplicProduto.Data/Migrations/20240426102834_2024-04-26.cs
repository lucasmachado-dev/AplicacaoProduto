using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicProduto.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20240426 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoAtividade = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Culturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeCientifico = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fazendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fazendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    ValorProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Safras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "date", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talhoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FazendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identificacao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talhoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talhoes_Fazendas_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "Fazendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CiclosProducao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SafraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CulturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "date", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiclosProducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CiclosProducao_Culturas_CulturaId",
                        column: x => x.CulturaId,
                        principalTable: "Culturas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CiclosProducao_Safras_SafraId",
                        column: x => x.SafraId,
                        principalTable: "Safras",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FazendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SafraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TalhaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CicloProducaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtividadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFinal = table.Column<DateOnly>(type: "date", nullable: false),
                    Executada = table.Column<bool>(type: "bit", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aplicacoes_CiclosProducao_CicloProducaoId",
                        column: x => x.CicloProducaoId,
                        principalTable: "CiclosProducao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Fazendas_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "Fazendas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Safras_SafraId",
                        column: x => x.SafraId,
                        principalTable: "Safras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Talhoes_TalhaoId",
                        column: x => x.TalhaoId,
                        principalTable: "Talhoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AplicacaoItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AplicacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeAplicada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacaoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AplicacaoItens_Aplicacoes_AplicacaoId",
                        column: x => x.AplicacaoId,
                        principalTable: "Aplicacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AplicacaoItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplicacaoItens_AplicacaoId",
                table: "AplicacaoItens",
                column: "AplicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AplicacaoItens_ProdutoId",
                table: "AplicacaoItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_AtividadeId",
                table: "Aplicacoes",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_CicloProducaoId",
                table: "Aplicacoes",
                column: "CicloProducaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_FazendaId",
                table: "Aplicacoes",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_SafraId",
                table: "Aplicacoes",
                column: "SafraId");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_TalhaoId",
                table: "Aplicacoes",
                column: "TalhaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CiclosProducao_CulturaId",
                table: "CiclosProducao",
                column: "CulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_CiclosProducao_SafraId",
                table: "CiclosProducao",
                column: "SafraId");

            migrationBuilder.CreateIndex(
                name: "IX_Talhoes_FazendaId",
                table: "Talhoes",
                column: "FazendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacaoItens");

            migrationBuilder.DropTable(
                name: "Aplicacoes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "CiclosProducao");

            migrationBuilder.DropTable(
                name: "Talhoes");

            migrationBuilder.DropTable(
                name: "Culturas");

            migrationBuilder.DropTable(
                name: "Safras");

            migrationBuilder.DropTable(
                name: "Fazendas");
        }
    }
}
