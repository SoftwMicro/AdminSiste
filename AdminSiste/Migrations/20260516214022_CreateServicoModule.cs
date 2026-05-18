using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminSiste.Migrations
{
    /// <inheritdoc />
    public partial class CreateServicoModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicoAtividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AtividadeServico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoServico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoTributacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoNBS = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CNAE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescricaoAtividade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoAtividades", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicoImpostos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PercentualISS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PercentualCOFINS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PercentualPIS = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PercentualCSLL = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PercentualIR = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PercentualINSS = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoImpostos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoInterno = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorCusto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comissao = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    ImpostosId = table.Column<int>(type: "int", nullable: false),
                    DescontarImpostos = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ConstrucaoCivil = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DescontarDeducoes = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BeneficioMunicipal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ArquivoUpload = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_ServicoAtividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "ServicoAtividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicos_ServicoImpostos_ImpostosId",
                        column: x => x.ImpostosId,
                        principalTable: "ServicoImpostos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_AtividadeId",
                table: "Servicos",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ImpostosId",
                table: "Servicos",
                column: "ImpostosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "ServicoAtividades");

            migrationBuilder.DropTable(
                name: "ServicoImpostos");
        }
    }
}
