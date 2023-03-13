using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class UniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "ProjectsBR",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DomainName",
                table: "DomainsModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "AccountsBR",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsBR_ProjectName",
                table: "ProjectsBR",
                column: "ProjectName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DomainsModel_DomainName",
                table: "DomainsModel",
                column: "DomainName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsBR_AccountName",
                table: "AccountsBR",
                column: "AccountName",
                unique: true,
                filter: "[AccountName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectsBR_ProjectName",
                table: "ProjectsBR");

            migrationBuilder.DropIndex(
                name: "IX_DomainsModel_DomainName",
                table: "DomainsModel");

            migrationBuilder.DropIndex(
                name: "IX_AccountsBR_AccountName",
                table: "AccountsBR");

            migrationBuilder.DropColumn(
                name: "DomainName",
                table: "DomainsModel");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "ProjectsBR",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "AccountsBR",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
