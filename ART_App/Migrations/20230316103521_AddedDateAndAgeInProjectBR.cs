using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class AddedDateAndAgeInProjectBR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "ProjectsBR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDate",
                table: "ProjectsBR",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "ProjectsBR");
        }
    }
}
