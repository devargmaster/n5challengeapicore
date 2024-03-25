using Common.GenericsMethods.GenericResponse;
using Data.Models;
using MediatR;

namespace Common.GenericsMethods;

public class UpdateCommand<T> : IRequest<Updater<T>>, IRequest<Unit> where T : BaseDomainEntity
{
    public T EntityToUpdate { get; }

    public UpdateCommand(T entity, Guid id)
    {
        EntityToUpdate = entity;
    }
}