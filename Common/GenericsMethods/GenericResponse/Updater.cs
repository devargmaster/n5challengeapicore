using Data.Models;

namespace Common.GenericsMethods.GenericResponse;

public class Updater <T> where T : BaseDomainEntity
{
    public Updater(BaseDomainEntity entity)
    {
       entity = entity;
    }

    public T UpdatedEntity { get; set; }
}