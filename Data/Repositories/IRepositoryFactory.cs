using Data.Models;

namespace Data.Repositories;

public interface IRepositoryFactory
{
    IRepository CreateRepository<T>() where T : BaseDomainEntity;
}