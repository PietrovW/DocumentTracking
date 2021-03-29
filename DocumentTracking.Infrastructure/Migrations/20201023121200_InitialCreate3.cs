using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentTracking.Infrastructure.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Received",
                schema: "Document",
                table: "Invoices");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceived",
                schema: "Document",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReceived",
                schema: "Document",
                table: "Invoices");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Received",
                schema: "Document",
                table: "Invoices",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
