using Xunit;
using CoreWebApi.Models.Entities;
using System;

namespace CoreWebApi.Tests.Models.Entities
{
    public class PermissionsTypeTests
    {
        [Fact]
        public void CreatePermissionsType_ChecksProperties()
        {
            // Arrange
            var descripcion = "Permiso de prueba";
            var tipoPermiso = new PermissionsType();

            // Act
            tipoPermiso.Descripcion = descripcion;

            // Assert
            Assert.Equal(descripcion, tipoPermiso.Descripcion);
        }
    }
}