using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sale.Catalog.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sale");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "sale");
        }
    }
}
