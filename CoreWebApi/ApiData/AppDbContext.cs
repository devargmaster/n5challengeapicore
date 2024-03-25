using CoreWebApi.Models.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.ApiData;

public class AppDbContext : DbContext, IDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
    }
    public DbContext GetContext()
    {
        return this;
    }

    public DbSet<Permissions> Permissions { get; set; }
    public DbSet<PermissionsType> PermissionsTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
    }
}