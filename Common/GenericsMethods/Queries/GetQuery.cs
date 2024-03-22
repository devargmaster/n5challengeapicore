using Common.GenericsMethods.GenericResponse;
using Data.Models;
using MediatR;

namespace Common.GenericsMethods.Queries;

public class GetQuery<T> : IRequest<GetResponse<T>> where T: BaseDomainEntity
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}