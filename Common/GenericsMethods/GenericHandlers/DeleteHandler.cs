using Data.Models;
using Data.Repositories;
using MediatR;

namespace Common.GenericsMethods.GenericHandlers;

public class DeleteHandler<T> : IRequestHandler<DeleteCommand, bool> where T : BaseDomainEntity
{
    private readonly IRepository _repository;

    public DeleteHandler(IRepositoryFactory repositoryFactory)
    {
        _repository = repositoryFactory.CreateRepository<T>();
    }
    
    public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.DeleteAsync<T>(request.Id);
        return entity != null ;
    }
}