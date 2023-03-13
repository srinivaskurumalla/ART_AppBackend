using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class DomainModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsBR_ProjectsBR_ProjectFkId",
                table: "ProjectsBR");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsBR_ProjectFkId",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "ProjectFkId",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "SkillSetRequired",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProjectsBR");

            migrationBuilder.CreateTable(
                name: "DomainsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    No_Of_Positions = table.Column<int>(type: "int", nullable: false),
                    Added_Modified_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectFkId = table.Column<int>(type: "int", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillSetRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainsModel_AccountsBR_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountsBR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DomainsModel_ProjectsBR_ProjectFkId",
                        column: x => x.ProjectFkId,
                        principalTable: "ProjectsBR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DomainsModel_SignUpModel_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "SignUpModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomainsModel_AccountId",
                table: "DomainsModel",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainsModel_EmployeeId",
                table: "DomainsModel",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainsModel_ProjectFkId",
                table: "DomainsModel",
                column: "ProjectFkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainsModel");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "ProjectsBR",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "ProjectsBR",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ProjectsBR",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "ProjectsBR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "ProjectsBR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectFkId",
                table: "ProjectsBR",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillSetRequired",
                table: "ProjectsBR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ProjectsBR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsBR_ProjectFkId",
                table: "ProjectsBR",
                column: "ProjectFkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsBR_ProjectsBR_ProjectFkId",
                table: "ProjectsBR",
                column: "ProjectFkId",
                principalTable: "ProjectsBR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
