using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotBlazorApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BotChartData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VWAP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SuperTrend = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HighPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotChartData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotChartData");
        }
    }
}
