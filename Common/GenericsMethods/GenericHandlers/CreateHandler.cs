using Common.GenericsMethods.GenericResponse;
using Data.Models;
using Data.Repositories;
using MediatR;

namespace Common.GenericsMethods.GenericHandlers;

public class CreateHandler<T> : IRequestHandler<CreateCommand<T>, CreateResponse<T>> where T : BaseDomainEntity
{
    private readonly IRepository _repository;

    public CreateHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateResponse<T>> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.CreateAsync(request.EntityToCreate);
        return new CreateResponse<T>(entity);
    }
}