using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class ReInitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsBR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "CONCAT('ACC',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsBR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignUpModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmpId = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "CONCAT('ICS',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsBR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "CONCAT('PR',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    EmployeelId = table.Column<int>(type: "int", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillSetRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsBR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsBR_AccountsBR_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountsBR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsBR_SignUpModel_EmployeelId",
                        column: x => x.EmployeelId,
                        principalTable: "SignUpModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterBR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "CONCAT('CA',RIGHT('000' + CAST(Id AS VARCHAR(3)), 3))"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        name: "FK_MasterBR_ProjectsBR_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsBR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterBR_ProjectId",
                table: "MasterBR",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsBR_AccountId",
                table: "ProjectsBR",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsBR_EmployeelId",
                table: "ProjectsBR",
                column: "EmployeelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterBR");

            migrationBuilder.DropTable(
                name: "ProjectsBR");

            migrationBuilder.DropTable(
                name: "AccountsBR");

            migrationBuilder.DropTable(
                name: "SignUpModel");
        }
    }
}
