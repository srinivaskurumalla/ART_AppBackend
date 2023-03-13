using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class RemoveUniqueDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DomainsModel_DomainName",
                table: "DomainsModel");

            migrationBuilder.AlterColumn<string>(
                name: "DomainName",
                table: "DomainsModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DomainName",
                table: "DomainsModel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_DomainsModel_DomainName",
                table: "DomainsModel",
                column: "DomainName",
                unique: true);
        }
    }
}
