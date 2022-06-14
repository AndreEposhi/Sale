using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sale.Inventory.Infra.Migrations
{
    public partial class InventoryInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sale");

            migrationBuilder.CreateTable(
                name: "Balance",
                schema: "sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance",
                schema: "sale");
        }
    }
}
