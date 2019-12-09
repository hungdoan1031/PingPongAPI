using Microsoft.EntityFrameworkCore.Migrations;

namespace PingPongAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShirtSizes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShirtSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TeamId = table.Column<string>(nullable: false),
                    ShirtSizeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_ShirtSizes_ShirtSizeId",
                        column: x => x.ShirtSizeId,
                        principalTable: "ShirtSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShirtSizes",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { "XS", "XS", 0 });

            migrationBuilder.InsertData(
                table: "ShirtSizes",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { "S", "S", 0 });

            migrationBuilder.InsertData(
                table: "ShirtSizes",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { "M", "M", 0 });

            migrationBuilder.InsertData(
                table: "ShirtSizes",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { "L", "L", 0 });

            migrationBuilder.InsertData(
                table: "ShirtSizes",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { "XL", "XL", 0 });

            migrationBuilder.InsertData(
                table: "ShirtSizes",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { "XXL", "XXL", 0 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { "Red", "#ff0000", "Red" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { "Black", "#000000", "Black" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_ShirtSizeId",
                table: "TeamMembers",
                column: "ShirtSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "ShirtSizes");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
