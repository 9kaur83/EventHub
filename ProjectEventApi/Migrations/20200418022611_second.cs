using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEventApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End_dateTime",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Start_dateTime",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Event");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Event",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Event");

            migrationBuilder.AddColumn<DateTime>(
                name: "End_dateTime",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start_dateTime",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Event",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
