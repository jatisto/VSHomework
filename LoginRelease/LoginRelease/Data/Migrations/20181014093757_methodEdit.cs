using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LoginRelease.Data.Migrations
{
    public partial class methodEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EditViewModel",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "EditViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "EditViewModel",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEnable",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "EditViewModel");

            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "EditViewModel");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "EditViewModel");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEnable",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
