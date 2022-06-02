using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamzaIndividueelProject.Migrations
{
    public partial class DepartementUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departement",
                table: "NewLogin");

            migrationBuilder.DropColumn(
                name: "Departement",
                table: "LoginData");

            migrationBuilder.AddColumn<string>(
                name: "Departement",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departement",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Departement",
                table: "NewLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Departement",
                table: "LoginData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
