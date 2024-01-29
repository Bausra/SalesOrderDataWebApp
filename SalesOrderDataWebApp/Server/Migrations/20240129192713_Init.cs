using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesOrderDataWebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    WindowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Windows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementNo = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    ElementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_Windows_WindowId",
                        column: x => x.WindowId,
                        principalTable: "Windows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BuyerName", "State" },
                values: new object[,]
                {
                    { 1, "New York Building 1", "NY" },
                    { 2, "California Hotel AJK", "CA" }
                });

            migrationBuilder.InsertData(
                table: "Windows",
                columns: new[] { "Id", "OrderId", "Quantity", "WindowName" },
                values: new object[,]
                {
                    { 1, 1, 4, "A51" },
                    { 2, 1, 2, "C Zone 5" },
                    { 3, 2, 3, "GLB" },
                    { 4, 2, 10, "OHF" }
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "ElementNo", "ElementType", "Height", "Width", "WindowId" },
                values: new object[,]
                {
                    { 1, 1, "Doors", 1850, 1200, 1 },
                    { 2, 2, "Window", 1850, 800, 1 },
                    { 3, 3, "Window", 1850, 700, 1 },
                    { 4, 1, "Window", 2000, 1500, 2 },
                    { 5, 1, "Doors", 2200, 1400, 3 },
                    { 6, 2, "Window", 2200, 600, 3 },
                    { 7, 1, "Window", 2000, 1500, 4 },
                    { 8, 1, "Window", 2000, 1500, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_WindowId",
                table: "Elements",
                column: "WindowId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_OrderId",
                table: "Windows",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
