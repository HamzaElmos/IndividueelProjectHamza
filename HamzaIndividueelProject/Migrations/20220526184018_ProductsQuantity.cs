using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamzaIndividueelProject.Migrations
{
    public partial class ProductsQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
