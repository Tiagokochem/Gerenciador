using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    ParceiroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParceiroNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParceiroFantasia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParceiroRazaoSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParceiroCep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ParceiroCidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParceiroEstado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ParceiroTelefone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParceiroEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParceiroAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.ParceiroId);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    PlanoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePlano = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TermoDeUso = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PrecoPlano = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DescontoPlano = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    tipoPlano = table.Column<int>(type: "int", nullable: false),
                    ParceiroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.PlanoId);
                    table.ForeignKey(
                        name: "FK_Planos_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiros",
                        principalColumn: "ParceiroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planos_ParceiroId",
                table: "Planos",
                column: "ParceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "Parceiros");
        }
    }
}
