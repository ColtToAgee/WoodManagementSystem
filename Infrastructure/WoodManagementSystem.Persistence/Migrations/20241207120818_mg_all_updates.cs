using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg_all_updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Patterns");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Orders",
                newName: "IsCancelled");

            migrationBuilder.AddColumn<string>(
                name: "PatternName",
                table: "Patterns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatternName",
                table: "Patterns");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsCancelled",
                table: "Orders",
                newName: "IsPaid");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Patterns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
