using DocumentTracking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DocumentTracking.Api.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddConfigureDatabases(this IServiceCollection services, IConfiguration config)
        {
           services.AddDbContext<DocumentTrackingContext>(c =>
                             c.UseNpgsql(config.GetConnectionString("DocumentTrackingConnection"),
                            x => x.MigrationsHistoryTable("__MigrationsHistory", "MigrationsHistoryDocumentTracking"))
                             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            return services;
        }

        public static IServiceCollection AddConfigureInMemoryDatabases(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DocumentTrackingContext>(c =>
                             c.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            return services;
        }
    }
}
