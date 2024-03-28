using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWebApi.Migrations
{
    public partial class ChangeIdToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionsTypes",
                table: "PermissionsTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PermissionsTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Permissions");

            migrationBuilder.AddColumn<int>(
                    name: "Id",
                    table: "PermissionsTypes",
                    type: "int",
                    nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                    name: "Id",
                    table: "Permissions",
                    type: "int",
                    nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionsTypes",
                table: "PermissionsTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionsTypes",
                table: "PermissionsTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PermissionsTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PermissionsTypes",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionsTypes",
                table: "PermissionsTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");
        }
    }
}