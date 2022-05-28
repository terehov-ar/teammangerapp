using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManageApp.Migrations
{
    public partial class ChangerealtioninTeamUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Team_CreaterId",
                table: "Team");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimateTo",
                table: "Team",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimateFrom",
                table: "Team",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CreaterId",
                table: "Team",
                column: "CreaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Team_CreaterId",
                table: "Team");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimateTo",
                table: "Team",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimateFrom",
                table: "Team",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CreaterId",
                table: "Team",
                column: "CreaterId",
                unique: true);
        }
    }
}
