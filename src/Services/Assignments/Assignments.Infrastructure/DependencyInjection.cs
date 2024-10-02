using System.Reflection;
using Assignments.Application.Common.Contracts;
using Assignments.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignments.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistanseLayer(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.Load("Assignments.Infrastructure"));
        });

        return services;
    }

    public static IServiceCollection AddSqliteConnection(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(o =>
        {
            o.UseSqlite("Data Source=data.db");
        });

        return services;
    }
}
