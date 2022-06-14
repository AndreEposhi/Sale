using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sale.Payment.Infra.Migrations
{
    public partial class PaymentInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sale");

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment",
                schema: "sale");
        }
    }
}
