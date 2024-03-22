using System.Linq.Expressions;
using Data.Models;

namespace Data.Repositories;

public interface IRepository
{
    Task<IEnumerable<T>> GetAsync<T>() where T : BaseDomainEntity;
}