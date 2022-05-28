using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManageApp.Migrations
{
    public partial class Addcommentstoissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Issue",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Issue");
        }
    }
}
