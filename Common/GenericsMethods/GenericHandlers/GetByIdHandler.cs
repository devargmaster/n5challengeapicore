using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Data.Models;
using Data.Repositories;
using MediatR;

namespace Common.GenericsMethods.GenericHandlers;

public class GetByIdHandler<T> : IRequestHandler<GetByIdQuery<T>, GetByIdResponse<T>> where T : BaseDomainEntity
{
    private readonly IRepository repository;

    public GetByIdHandler(IRepositoryFactory repository)
    {
        this.repository = repository.CreateRepository<T>();
    }
    
    public async Task<GetByIdResponse<T>> Handle(GetByIdQuery<T> request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync<T>(request.Id);
        return new GetByIdResponse<T>(entity);
    }
}