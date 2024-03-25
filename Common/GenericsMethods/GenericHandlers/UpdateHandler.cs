using Common.GenericsMethods.GenericResponse;
using Data.Models;
using Data.Repositories;
using MediatR;

namespace Common.GenericsMethods.GenericHandlers


{
    public class UpdateHandler<T> : IRequestHandler<UpdateCommand<T>, Unit> where T : BaseDomainEntity
    {
        private readonly IRepository repository;

        public UpdateHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = await repository.UpdateAsync<T>(request.EntityToUpdate, request.EntityToUpdate.Id);
            return Unit.Value;
        }
    }
}