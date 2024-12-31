using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg_user_update_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshPasswordCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshPasswordCodeExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshPasswordCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshPasswordCodeExpiryTime",
                table: "AspNetUsers");
        }
    }
}
