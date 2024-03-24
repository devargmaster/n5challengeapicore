using Data.Models;
using MediatR;

namespace Common.GenericsMethods;

public class UpdateCommand<T> : IRequest<T> where T : BaseDomainEntity
{
    public T EntityToUpdate { get; }

    public UpdateCommand(T entity)
    {
        EntityToUpdate = entity;
    }
}