using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class Added_Modifies_In_Master_Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Added_Modified_By",
                table: "ProjectsBR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Added_Modified_By",
                table: "MasterBR",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Added_Modified_By",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "Added_Modified_By",
                table: "MasterBR");
        }
    }
}
