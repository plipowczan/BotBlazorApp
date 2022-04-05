using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotBlazorApp.Migrations
{
    public partial class ChangedBotChartDataStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMA",
                table: "BotChartData");

            migrationBuilder.DropColumn(
                name: "SuperTrend",
                table: "BotChartData");

            migrationBuilder.RenameColumn(
                name: "VWAP",
                table: "BotChartData",
                newName: "EMA200");

            migrationBuilder.AddColumn<decimal>(
                name: "EmaInDown",
                table: "BotChartData",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmaInUp",
                table: "BotChartData",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmaOutDown",
                table: "BotChartData",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmaOutUp",
                table: "BotChartData",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeStamp",
                table: "BotChartData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmaInDown",
                table: "BotChartData");

            migrationBuilder.DropColumn(
                name: "EmaInUp",
                table: "BotChartData");

            migrationBuilder.DropColumn(
                name: "EmaOutDown",
                table: "BotChartData");

            migrationBuilder.DropColumn(
                name: "EmaOutUp",
                table: "BotChartData");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "BotChartData");

            migrationBuilder.RenameColumn(
                name: "EMA200",
                table: "BotChartData",
                newName: "VWAP");

            migrationBuilder.AddColumn<decimal>(
                name: "EMA",
                table: "BotChartData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SuperTrend",
                table: "BotChartData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
