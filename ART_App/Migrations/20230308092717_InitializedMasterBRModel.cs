using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class InitializedMasterBRModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProjectsBR",
                newName: "ProjectName");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "ProjectsBR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateTable(
                name: "MasterBR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectsBRModelId = table.Column<int>(type: "int", nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Int_Ext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillSetRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ScreeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScreeningResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L1_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    L1_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Client_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manager_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eval_Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterBR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterBR_ProjectsBR_ProjectsBRModelId",
                        column: x => x.ProjectsBRModelId,
                        principalTable: "ProjectsBR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterBR_ProjectsBRModelId",
                table: "MasterBR",
                column: "ProjectsBRModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterBR");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "SkillSetRequired",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProjectsBR");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "ProjectsBR",
                newName: "Name");
        }
    }
}
