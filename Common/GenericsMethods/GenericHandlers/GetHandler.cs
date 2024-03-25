using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Data.Models;
using Data.Repositories;
using MediatR;

namespace Common.GenericsMethods.GenericHandlers;

public class GetHandler<T> : IRequestHandler<GetQuery<T>, GetResponse<T>> where T : BaseDomainEntity
{
    private readonly IRepository repository;

    public GetHandler(IRepositoryFactory repository)
    {
        this.repository = repository.CreateRepository<T>();
    }
    
    public async Task<GetResponse<T>> Handle(GetQuery<T> request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAsync<T>();
        return new GetResponse<T>(result);
    }
}