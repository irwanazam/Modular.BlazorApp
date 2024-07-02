using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modular.Api.Audits.Migrations
{
    /// <inheritdoc />
    public partial class Update_AuditEvent_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityName",
                table: "AuditEvents");

            migrationBuilder.DropColumn(
                name: "EntityPreviousValue",
                table: "AuditEvents");

            migrationBuilder.RenameColumn(
                name: "EntityValue",
                table: "AuditEvents",
                newName: "Message");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "AuditEvents",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "AuditEvents",
                newName: "EntityValue");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "AuditEvents",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "EntityName",
                table: "AuditEvents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EntityPreviousValue",
                table: "AuditEvents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
