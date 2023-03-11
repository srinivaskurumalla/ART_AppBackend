using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class FkSpellChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsBR_SignUpModel_EmployeelId",
                table: "ProjectsBR");

            migrationBuilder.RenameColumn(
                name: "EmployeelId",
                table: "ProjectsBR",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectsBR_EmployeelId",
                table: "ProjectsBR",
                newName: "IX_ProjectsBR_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsBR_SignUpModel_EmployeeId",
                table: "ProjectsBR",
                column: "EmployeeId",
                principalTable: "SignUpModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsBR_SignUpModel_EmployeeId",
                table: "ProjectsBR");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ProjectsBR",
                newName: "EmployeelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectsBR_EmployeeId",
                table: "ProjectsBR",
                newName: "IX_ProjectsBR_EmployeelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsBR_SignUpModel_EmployeelId",
                table: "ProjectsBR",
                column: "EmployeelId",
                principalTable: "SignUpModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
