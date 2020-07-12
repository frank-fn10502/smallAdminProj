using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace User_Order_API_Core.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    PID = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Status = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Product",
                        column: x => x.PID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipping Order",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    OrderID = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shipping Order_Order",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Name", "Price" },
                values: new object[,]
                {
                    { "PD001", "Product1", 1300m },
                    { "PD002", "Product2", 2000000m },
                    { "PD003", "Product3", 45000m },
                    { "PD004", "Product4", 200m }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "ID", "Cost", "PID", "Price", "Status" },
                values: new object[,]
                {
                    { "A20202026001", 90m, "PD001", 100m, (short)0 },
                    { "A20202023001", 100m, "PD002", 120m, (short)0 },
                    { "A20202026002", 150m, "PD003", 200m, (short)0 },
                    { "A20202024003", 120m, "PD004", 150m, (short)0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PID",
                table: "Order",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping Order_OrderID",
                table: "Shipping Order",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipping Order");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
