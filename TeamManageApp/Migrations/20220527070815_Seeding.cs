using Microsoft.EntityFrameworkCore.Migrations;
using TeamManageApp.Data;

#nullable disable

namespace TeamManageApp.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //ADD NEW USER
            migrationBuilder.InsertData(
            table: "User",
            columns: new[]
            {
                     "Login",
                     "Role",
                     "Password",
                     "FullName",
                     "TeamId"
            },
            values: new object[]
            {
                     "Phoebe",
                     Constants.Developer,
                     "$2a$13$9PGtZWkMzcElmBIQg.Tuq.BMP9YYMCufZTFoxMkK354eJxvANU07G", //0000
                     "Phoebe Buffay-Hannigan",
                     null
            });

            //ADD NEW TEAM
            migrationBuilder.InsertData(
            table: "Team",
            columns: new[]
            {
                    "Name",
                    "Description",
                    "Comments",
                    "Methodologies",
                    "EstimateFrom",
                    "EstimateTo",
                    "CreaterId",
            },
            values: new object[]
            {
                    "Project 'Active Fitness'",
                    "Fitness portal for adding new clients and managing of client accounts and training programs",
                    "Costs a lot of money",
                    "Scram",
                    new DateTime(2022, 5, 2),
                    new DateTime(2022, 11, 12),
                    1
            });

            //UPDATE USER WHO TEAM CREATER
            migrationBuilder.UpdateData(
            table: "User",
            keyColumn: "Id",
            keyValue: 1,
            column: "TeamId",
            value: 1);

            //ADD NEW USER
            migrationBuilder.InsertData(
            table: "User",
            columns: new[]
            {
                    "Login",
                    "Role",
                    "Password",
                    "FullName",
                    "TeamId"
            },
            values: new object[]
            {
                    "Rachel",
                    Constants.QA,
                    "$2a$13$9PGtZWkMzcElmBIQg.Tuq.BMP9YYMCufZTFoxMkK354eJxvANU07G", //0000
                    "Rachel Karen Green",
                    1
            });

            //ADD NEW USER
            migrationBuilder.InsertData(
            table: "User",
            columns: new[]
            {
                    "Login",
                    "Role",
                    "Password",
                    "FullName",
                    "TeamId"
            },
            values: new object[]
            {
                    "Monica",
                    Constants.Analytic,
                    "$2a$13$9PGtZWkMzcElmBIQg.Tuq.BMP9YYMCufZTFoxMkK354eJxvANU07G", //0000
                    "Monica Geller",
                    1
            });

            //ADD NEW USER
            migrationBuilder.InsertData(
            table: "User",
            columns: new[]
            {
                    "Login",
                    "Role",
                    "Password",
                    "FullName",
                    "TeamId"
            },
            values: new object[]
            {
                    "Joey",
                    Constants.Developer,
                    "$2a$13$9PGtZWkMzcElmBIQg.Tuq.BMP9YYMCufZTFoxMkK354eJxvANU07G", //0000
                    "Joseph Francis \"Joey\" Tribbiani Jr.",
                    1
            });

            //ADD NEW USER
            migrationBuilder.InsertData(
            table: "User",
            columns: new[]
            {
                    "Login",
                    "Role",
                    "Password",
                    "FullName",
                    "TeamId"
            },
            values: new object[]
            {
                    "Chandler",
                    Constants.ProjectManager,
                    "$2a$13$9PGtZWkMzcElmBIQg.Tuq.BMP9YYMCufZTFoxMkK354eJxvANU07G", //0000
                    "Chandler Muriel Bing",
                    1
            });

            //ADD NEW ISSUE
            migrationBuilder.InsertData(
            table: "Issue",
            columns: new[]
            {
                    "Name",
                    "Description",
                    "Priority",
                    "Status",
                    "Comments",
                    "ListId",
                    "TeamId",
                    "ReporterId",
                    "AsigneeId"
            },
            values: new object[]
            {
                    "Base repository",
                    "To create base repository for all entities in project",
                    "Critical",
                    "OPEN",
                    "Be carefull, models can be change, so - do it abstract",
                    null,
                    1,
                    3,
                    4
            });

            //ADD NEW ISSUE
            migrationBuilder.InsertData(
            table: "Issue",
            columns: new[]
            {
                    "Name",
                    "Description",
                    "Priority",
                    "Status",
                    "Comments",
                    "ListId",
                    "TeamId",
                    "ReporterId",
                    "AsigneeId"
            },
            values: new object[]
            {
                    "Pay - Killer super feature",
                    "To create pay system by NFC, to create paying module",
                    "Critical",
                    "OPEN",
                    "Any questions to me",
                    null,
                    1,
                    2,
                    1
            });

            //ADD ISSUELIST FOR LINKED ISSUES
            migrationBuilder.InsertData(
            table: "IssueList",
            columns: new[]
            {
                    "MainIssueId"
            },
            values: new object[]
            {
                    2
            });

            //UPDATE ISSUE TO ADD LINKED ISSUES
            migrationBuilder.UpdateData(
            table: "Issue",
            keyColumn: "Id",
            keyValue: 1,
            column: "ListId",
            value: 1);



            //ADD NEW USER
            migrationBuilder.InsertData(
            table: "User",
            columns: new[]
            {
                    "Login",
                    "Role",
                    "Password",
                    "FullName",
                    "TeamId"
            },
            values: new object[]
            {
                    "Arthur",
                    Constants.Developer,
                    "$2a$13$9PGtZWkMzcElmBIQg.Tuq.BMP9YYMCufZTFoxMkK354eJxvANU07G", //0000
                    "Arthur Terekhov",
                    null
            });

            //ADD NEW TEAM
            migrationBuilder.InsertData(
            table: "Team",
            columns: new[]
            {
                    "Name",
                    "Description",
                    "Comments",
                    "Methodologies",
                    "EstimateFrom",
                    "EstimateTo",
                    "CreaterId",
            },
            values: new object[]
            {
                    "Office",
                    "No description",
                    "That was she said",
                    "Waterfall",
                    new DateTime(2022, 5, 2),
                    new DateTime(2024, 11, 12),
                    6
            });

            //UPDATE USER WHO TEAM CREATER
            migrationBuilder.UpdateData(
            table: "User",
            keyColumn: "Id",
            keyValue: 6,
            column: "TeamId",
            value: 2);

            //ADD NEW ISSUE
            migrationBuilder.InsertData(
            table: "Issue",
            columns: new[]
            {
                    "Name",
                    "Description",
                    "Priority",
                    "Status",
                    "Comments",
                    "ListId",
                    "TeamId",
                    "ReporterId",
                    "AsigneeId"
            },
            values: new object[]
            {
                    "Task1",
                    "Delete legacy code",
                    "Normal",
                    "OPEN",
                    "NO COMMENTS!",
                    null,
                    2,
                    6,
                    6
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
