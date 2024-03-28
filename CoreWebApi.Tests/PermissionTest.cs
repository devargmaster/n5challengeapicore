using Xunit;
using CoreWebApi.Models.Entities;

namespace CoreWebApi.Tests.Models.Entities
{
    public class PermissionsTests
    {
        [Fact]
        public void AddPermissionToList_ChecksIfListContainsPermission()
        {
            // Arrange
            var permiso = new Permissions
            {
                NombreEmpleado = "Juan",
                ApellidoEmpleado = "Perez",
                FechaPermiso = DateTime.Now,
                TipoPermisoId = Guid.NewGuid()
            };

            var tipoPermiso = new PermissionsType
            {
                Descripcion = "Permiso de prueba"
            };

            var permisos = new List<Permissions>();
            // Act
            permisos.Add(permiso);

            // Assert
            Assert.Contains(permiso, permisos);
        }
    }
}