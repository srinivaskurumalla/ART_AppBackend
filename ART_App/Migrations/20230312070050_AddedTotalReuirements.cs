using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class AddedTotalReuirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "No_Of_Positions",
                table: "ProjectsBR",
                newName: "Total_Positions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total_Positions",
                table: "ProjectsBR",
                newName: "No_Of_Positions");
        }
    }
}
