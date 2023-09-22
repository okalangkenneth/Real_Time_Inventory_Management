using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetails",
                columns: table => new
                {
                    ReportDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetails", x => x.ReportDetailId);
                    table.ForeignKey(
                        name: "FK_ReportDetails_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 22, 23, 32, 19, 276, DateTimeKind.Local).AddTicks(5699), "Sales data for the month", "Monthly Sales", new DateTime(2023, 9, 22, 23, 32, 19, 276, DateTimeKind.Local).AddTicks(5746) },
                    { 2, new DateTime(2023, 9, 22, 23, 32, 19, 276, DateTimeKind.Local).AddTicks(5750), "Revenue data for the quarter", "Quarterly Revenue", new DateTime(2023, 9, 22, 23, 32, 19, 276, DateTimeKind.Local).AddTicks(5752) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Username" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "john_doe" },
                    { 2, "jane.doe@example.com", "jane_doe" }
                });

            migrationBuilder.InsertData(
                table: "ReportDetails",
                columns: new[] { "ReportDetailId", "Data", "ReportId", "Type" },
                values: new object[] { 1, "Some data for Monthly Sales", 1, "Table" });

            migrationBuilder.InsertData(
                table: "ReportDetails",
                columns: new[] { "ReportDetailId", "Data", "ReportId", "Type" },
                values: new object[] { 2, "Some more data for Monthly Sales", 1, "Chart" });

            migrationBuilder.InsertData(
                table: "ReportDetails",
                columns: new[] { "ReportDetailId", "Data", "ReportId", "Type" },
                values: new object[] { 3, "Some data for Quarterly Revenue", 2, "Table" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
