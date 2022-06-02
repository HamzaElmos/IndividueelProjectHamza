using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamzaIndividueelProject.Migrations
{
    public partial class Newuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NewUsers",
                newName: "ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatedJoined",
                table: "NewUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Departement",
                table: "NewUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "NewUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "NewUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "NewUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatedJoined",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "Departement",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "NewUsers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "NewUsers");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "NewUsers",
                newName: "Id");
        }
    }
}
