using Data.Models;

namespace CoreWebApi.Models.Entities;

public class PermissionsType : BaseDomainEntity
{
    public string Descripcion { get; set; }
    public ICollection<Permissions> Permissions { get; set; }
}