using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class EvalChangeToMasterBR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationModel");

            migrationBuilder.CreateTable(
                name: "MasterBR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "CONCAT('CA',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Int_Ext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillSetRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ScreeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScreeningResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L1_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    L1_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Client_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Manager_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eval_Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Added_Modified_By = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterBR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterBR_ProjectsBR_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsBR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MasterBR_SignUpModel_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "SignUpModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterBR_EmployeeId",
                table: "MasterBR",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterBR_ProjectId",
                table: "MasterBR",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterBR");

            migrationBuilder.CreateTable(
                name: "EvaluationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Added_Modified_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "CONCAT('CA',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Client_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Eval_Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Int_Ext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L1_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    L1_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager_Eval_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Manager_Eval_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ScreeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScreeningResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillSetRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationModel_ProjectsBR_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsBR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationModel_SignUpModel_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "SignUpModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationModel_EmployeeId",
                table: "EvaluationModel",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationModel_ProjectId",
                table: "EvaluationModel",
                column: "ProjectId");
        }
    }
}
