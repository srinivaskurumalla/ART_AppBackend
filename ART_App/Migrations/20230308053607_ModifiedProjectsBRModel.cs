using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class ModifiedProjectsBRModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProjectsBR_AccountsBRModelId",
                table: "ProjectsBR",
                column: "AccountsBRModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsBR_AccountsBR_AccountsBRModelId",
                table: "ProjectsBR",
                column: "AccountsBRModelId",
                principalTable: "AccountsBR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsBR_AccountsBR_AccountsBRModelId",
                table: "ProjectsBR");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsBR_AccountsBRModelId",
                table: "ProjectsBR");
        }
    }
}
