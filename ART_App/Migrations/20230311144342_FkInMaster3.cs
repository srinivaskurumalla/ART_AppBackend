using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class FkInMaster3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "MasterBR",
                type: "int",
                nullable: false,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_MasterBR_EmployeeId",
                table: "MasterBR",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterBR_SignUpModel_EmployeeId",
                table: "MasterBR",
                column: "EmployeeId",
                principalTable: "SignUpModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterBR_SignUpModel_EmployeeId",
                table: "MasterBR");

            migrationBuilder.DropIndex(
                name: "IX_MasterBR_EmployeeId",
                table: "MasterBR");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "MasterBR");
        }
    }
}
