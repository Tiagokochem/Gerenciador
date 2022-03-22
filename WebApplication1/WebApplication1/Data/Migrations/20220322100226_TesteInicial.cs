using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    public partial class TesteInicial : Migration
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
                    ParceiroCep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ParceiroCidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParceiroEstado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ParceiroTelefone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.ParceiroId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parceiros");
        }
    }
}
