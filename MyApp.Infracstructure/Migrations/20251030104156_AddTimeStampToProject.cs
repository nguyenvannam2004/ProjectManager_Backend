using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeStampToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_CreatedAt",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_EndDate",
                table: "Task",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_StartDate",
                table: "Task",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_UpdatedAt",
                table: "Task",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_CreatedAt",
                table: "Stage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_EndDate",
                table: "Stage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_StartDate",
                table: "Stage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_UpdatedAt",
                table: "Stage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_CreatedAt",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_EndDate",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_StartDate",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp_UpdatedAt",
                table: "Projects",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp_CreatedAt",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TimeStamp_EndDate",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TimeStamp_StartDate",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TimeStamp_UpdatedAt",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TimeStamp_CreatedAt",
                table: "Stage");

            migrationBuilder.DropColumn(
                name: "TimeStamp_EndDate",
                table: "Stage");

            migrationBuilder.DropColumn(
                name: "TimeStamp_StartDate",
                table: "Stage");

            migrationBuilder.DropColumn(
                name: "TimeStamp_UpdatedAt",
                table: "Stage");

            migrationBuilder.DropColumn(
                name: "TimeStamp_CreatedAt",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TimeStamp_EndDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TimeStamp_StartDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TimeStamp_UpdatedAt",
                table: "Projects");
        }
    }
}
