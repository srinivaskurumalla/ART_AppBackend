﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ART_App.Migrations
{
    public partial class DomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "ProjectsBR",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "ProjectsBR",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ProjectsBR",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProjectFkId",
                table: "ProjectsBR",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsBR_ProjectFkId",
                table: "ProjectsBR",
                column: "ProjectFkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsBR_ProjectsBR_ProjectFkId",
                table: "ProjectsBR",
                column: "ProjectFkId",
                principalTable: "ProjectsBR",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsBR_ProjectsBR_ProjectFkId",
                table: "ProjectsBR");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsBR_ProjectFkId",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ProjectsBR");

            migrationBuilder.DropColumn(
                name: "ProjectFkId",
                table: "ProjectsBR");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "ProjectsBR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "ProjectsBR",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
