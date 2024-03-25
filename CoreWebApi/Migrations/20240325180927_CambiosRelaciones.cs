using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CambiosRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionsTypes_TipoPermisoId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_TipoPermisoId",
                table: "Permissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Permissions_TipoPermisoId",
                table: "Permissions",
                column: "TipoPermisoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionsTypes_TipoPermisoId",
                table: "Permissions",
                column: "TipoPermisoId",
                principalTable: "PermissionsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
