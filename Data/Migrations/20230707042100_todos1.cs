using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class todos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "ToDos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemind",
                table: "ToDos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "ToDos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "ToDos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ToDos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "IsRemind",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ToDos");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
