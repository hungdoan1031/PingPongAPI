using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PingPongAPI.Migrations
{
    public partial class AddLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    LogLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "L",
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "M",
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "S",
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "XL",
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "XXL",
                column: "Order",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "L",
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "M",
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "S",
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "XL",
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShirtSizes",
                keyColumn: "Id",
                keyValue: "XXL",
                column: "Order",
                value: 0);
        }
    }
}
