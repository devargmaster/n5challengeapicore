using MediatR;

namespace Common.GenericsMethods;

public class DeleteCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteCommand(Guid id)
    {
        Id = id;
    }
}