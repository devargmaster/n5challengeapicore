using Data.Models;
using MediatR;

namespace Common.GenericsMethods.Queries;

public class GetByIdQuery<T> : IRequest<T> where T : BaseDomainEntity
{
    public Guid Id { get; }

    public GetByIdQuery(Guid id)
    {
        Id = id;
    }
}