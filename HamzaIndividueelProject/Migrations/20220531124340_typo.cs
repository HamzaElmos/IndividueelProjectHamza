using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamzaIndividueelProject.Migrations
{
    public partial class typo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "ContactNameoOrder",
                table: "Orders",
                newName: "ContactNameOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Products",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ContactNameOrder",
                table: "Orders",
                newName: "ContactNameoOrder");
        }
    }
}
