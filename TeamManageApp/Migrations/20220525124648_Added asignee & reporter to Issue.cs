using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManageApp.Migrations
{
    public partial class AddedasigneereportertoIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_User_UserId",
                table: "Issue");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Issue",
                newName: "ReporterId");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_UserId",
                table: "Issue",
                newName: "IX_Issue_ReporterId");

            migrationBuilder.AddColumn<int>(
                name: "AsigneeId",
                table: "Issue",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Issue_AsigneeId",
                table: "Issue",
                column: "AsigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_User_AsigneeId",
                table: "Issue",
                column: "AsigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_User_ReporterId",
                table: "Issue",
                column: "ReporterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_User_AsigneeId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_User_ReporterId",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_AsigneeId",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "AsigneeId",
                table: "Issue");

            migrationBuilder.RenameColumn(
                name: "ReporterId",
                table: "Issue",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_ReporterId",
                table: "Issue",
                newName: "IX_Issue_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_User_UserId",
                table: "Issue",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
