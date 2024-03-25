using Common.GenericsMethods.GenericResponse;
using Data.Models;
using MediatR;

namespace Common.GenericsMethods.Queries;

public class GetByIdQuery<T> : IRequest<GetByIdResponse<T>> where T : BaseDomainEntity
{
    public Guid Id { get; }

    public GetByIdQuery(Guid id)
    {
        Id = id;
    }
}