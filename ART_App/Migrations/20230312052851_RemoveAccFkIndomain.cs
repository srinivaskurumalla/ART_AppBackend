using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class RemoveAccFkIndomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DomainsModel_AccountsBR_AccountId",
                table: "DomainsModel");

            migrationBuilder.DropIndex(
                name: "IX_DomainsModel_AccountId",
                table: "DomainsModel");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "DomainsModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "DomainsModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DomainsModel_AccountId",
                table: "DomainsModel",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_DomainsModel_AccountsBR_AccountId",
                table: "DomainsModel",
                column: "AccountId",
                principalTable: "AccountsBR",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
