using Common.GenericsMethods;
using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using CoreWebApi.ApiData;
using CoreWebApi.Models.Entities;
using Data.Contexts;
using Data.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
namespace CoreWebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5 Challenge", Version = "v1" });
        });

        services.AddMediatR(typeof(CreateHandler<Permissions>).Assembly);
        services.AddMediatR(typeof(CreateHandler<Permissions>).Assembly, typeof(CreateHandler<PermissionsType>).Assembly);
        services.AddScoped(typeof(IRequestHandler<CreateCommand<PermissionsType>, CreateResponse<PermissionsType>>), typeof(CreateHandler<PermissionsType>));
        services.AddScoped(typeof(IRequestHandler<CreateCommand<Permissions>, CreateResponse<Permissions>>), typeof(CreateHandler<Permissions>));
        services.AddScoped(typeof(IRequestHandler<UpdateCommand<Permissions>, Updater<Permissions>>), typeof(UpdateHandler<Permissions>));
        services.AddScoped(typeof(IRequestHandler<UpdateCommand<PermissionsType>, Updater<PermissionsType>>), typeof(UpdateHandler<PermissionsType>));
        services.AddScoped(typeof(IRequestHandler<GetQuery<PermissionsType>, GetResponse<PermissionsType>>), typeof(GetHandler<PermissionsType>));
        services.AddScoped(typeof(IRequestHandler<GetQuery<Permissions>, GetResponse<Permissions>>), typeof(GetHandler<Permissions>));
        services.AddScoped(typeof(IRequestHandler<GetByIdQuery<Permissions>, GetByIdResponse<Permissions>>), typeof(GetByIdHandler<Permissions>));
        services.AddScoped(typeof(IRequestHandler<GetByIdQuery<PermissionsType>, GetByIdResponse<PermissionsType>>), typeof(GetByIdHandler<PermissionsType>));
        services.AddScoped(typeof(IRequestHandler<DeleteCommand, bool>), typeof(DeleteHandler<Permissions>));
        services.AddScoped(typeof(IRequestHandler<DeleteCommand, bool>), typeof(DeleteHandler<PermissionsType>));
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        services.AddScoped<SqlRepository>();
        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<IRepository, SqlRepository>();
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetSection("ConnectionString:SqlServerConnection").Value));
        services.AddScoped<IDbContext>(provider => provider.GetService<AppDbContext>());
       
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5 Challenge v1"));
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}