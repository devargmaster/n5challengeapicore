using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermissionsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionsTypes_PermissionsTypeId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionsTypeId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "PermissionsTypeId",
                table: "Permissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PermissionsTypeId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionsTypeId",
                table: "Permissions",
                column: "PermissionsTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionsTypes_PermissionsTypeId",
                table: "Permissions",
                column: "PermissionsTypeId",
                principalTable: "PermissionsTypes",
                principalColumn: "Id");
        }
    }
}
