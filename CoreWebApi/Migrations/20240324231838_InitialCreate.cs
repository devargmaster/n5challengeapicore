using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionsTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPermiso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoPermisoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionsTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionsTypes_PermissionsTypeId",
                        column: x => x.PermissionsTypeId,
                        principalTable: "PermissionsTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionsTypes_TipoPermisoId",
                        column: x => x.TipoPermisoId,
                        principalTable: "PermissionsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionsTypeId",
                table: "Permissions",
                column: "PermissionsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_TipoPermisoId",
                table: "Permissions",
                column: "TipoPermisoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionsTypes");
        }
    }
}
