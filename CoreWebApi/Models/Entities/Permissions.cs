using Data.Models;

namespace CoreWebApi.Models.Entities;

public class Permissions : BaseDomainEntity
{
    public string NombreEmpleado { get; set; }
    public string ApellidoEmpleado { get; set; }
    public int TipoPermiso { get; set; }
    public DateTime FechaPermiso { get; set; }
}