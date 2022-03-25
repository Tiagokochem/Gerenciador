using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    public partial class I : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParceiroId",
                table: "Parceiros",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ParceiroRazaoSocial",
                table: "Parceiros",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParceiroRazaoSocial",
                table: "Parceiros");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parceiros",
                newName: "ParceiroId");
        }
    }
}
