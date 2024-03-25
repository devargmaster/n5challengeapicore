using Data.Models;
using MediatR;

namespace Common.GenericsMethods;

public class DeleteCommand<T> : IRequest<Unit> where T : BaseDomainEntity
{
    public Guid Id { get; }

    public DeleteCommand(Guid id)
    {
        Id = id;
    }
}