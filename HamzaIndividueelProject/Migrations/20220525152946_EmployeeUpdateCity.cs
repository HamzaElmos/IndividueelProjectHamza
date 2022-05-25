using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamzaIndividueelProject.Migrations
{
    public partial class EmployeeUpdateCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Employees");
        }
    }
}
