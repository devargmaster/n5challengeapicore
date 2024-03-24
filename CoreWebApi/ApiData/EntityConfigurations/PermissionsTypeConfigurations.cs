using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreWebApi.Models.Entities;
namespace CoreWebApi.ApiData.EntityConfigurations;

public class PermissionsTypeConfigurations: IEntityTypeConfiguration<PermissionsType>
{
    public void Configure(EntityTypeBuilder<PermissionsType> builder)
    {
         builder
                   .HasMany(pt => pt.Permissions)
                    .WithOne(p => p.PermissionsType)
                    .HasForeignKey(p => p.TipoPermisoId);
    }
    
}