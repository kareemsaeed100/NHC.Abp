using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace NHC.Abp.Migrations
{
    /// <inheritdoc />
    public partial class ConvertUserIdFromLongToGUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId_New",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "UserId_New",
                table: "Notification",
                newName: "UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId_Old",
                table: "Notification",
                type: "bigint",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "UserId_Old",
                table: "Notification",
                newName: "UserId");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Notification",
                type: "bigint",
                nullable: false);
        }

    }
}
