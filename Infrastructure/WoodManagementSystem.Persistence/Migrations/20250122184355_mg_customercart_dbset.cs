using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg_customercart_dbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false),
                    CustomerUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCartId = table.Column<int>(type: "int", nullable: false),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    DimensionWidth = table.Column<double>(type: "float", nullable: false),
                    DimensionLength = table.Column<double>(type: "float", nullable: false),
                    DimensionX = table.Column<double>(type: "float", nullable: false),
                    DimensionY = table.Column<double>(type: "float", nullable: false),
                    EdgeBand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCartItems_CustomerCarts_CustomerCartId",
                        column: x => x.CustomerCartId,
                        principalTable: "CustomerCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCartItems_Patterns_PatternId",
                        column: x => x.PatternId,
                        principalTable: "Patterns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCartItems_CustomerCartId",
                table: "CustomerCartItems",
                column: "CustomerCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCartItems_PatternId",
                table: "CustomerCartItems",
                column: "PatternId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCartItems");

            migrationBuilder.DropTable(
                name: "CustomerCarts");
        }
    }
}
