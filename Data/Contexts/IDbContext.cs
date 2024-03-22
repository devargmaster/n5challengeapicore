
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public interface IDbContext
{
        /// <summary>
        /// Gets an instance of the DbContext.
        /// </summary>
        /// <returns>An instance of the DbContext.</returns>
        DbContext GetContext();
    
}