using Data.Contexts;
using Data.Models;
using Exceptions.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repositories;

public class SqlRepository : IRepository
{
    private readonly DbContext context;
    private readonly ILogger logger;

    public SqlRepository(IDbContext context, ILogger<SqlRepository> logger)
    {
        this.context = context.GetContext();
        this.logger = logger;
    }
    
    public async Task<IEnumerable<T>> GetAsync<T>() where T : BaseDomainEntity
    {
         try
         {
             var entities = await context.Set<T>().ToListAsync();

             logger.LogInformation($"Entities of type {typeof(T).Name} queried from Sql Server.");

             return entities;
         }
         catch (Exception ex)
         {
             logger.LogError(ex, $"Error retrieving entities of type {typeof(T).Name} with filter.");
             return null;
         }
    }
    
}